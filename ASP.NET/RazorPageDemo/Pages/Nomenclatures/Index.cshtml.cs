using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPageDemo.Data;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RazorPageDemo.Pages.Nomenclatures
{
    [Authorize(Roles ="Administrator")]
    //[Authorize]
    public class IndexModel : PageModel //Nomenclatures/Index
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RazorPageDemo.Data.CafeDbContext _context;
        [BindProperty(SupportsGet =true)]
        public string Filter { get; set; }=string.Empty;

        [BindProperty]
        public IFormFile Upload { get; set; }

        [BindProperty(SupportsGet =true)]
        public int LinesPerPage { get; set; } =10;
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int Pages { get; set; }


        public IndexModel(RazorPageDemo.Data.CafeDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Nomenclature> Nomenclature { get;set; } = default!;

        async Task RefreshData()
        {
            var query = _context.Nomenclatures.AsQueryable();
            if (!string.IsNullOrWhiteSpace(Filter)) query = query.Where(s => s.Name.Contains(Filter));

            Nomenclature = await _context.Nomenclatures.OrderBy(o => o.Id).Skip((CurrentPage - 1) * LinesPerPage).Take(LinesPerPage).ToListAsync();
            Count = await query.CountAsync();
            Pages = Count/LinesPerPage +((Count % LinesPerPage)==0?0:1);

        }

        public async Task OnGetAsync()
        {
            var cookieIsInRole = User.IsInRole("Administrator");

            var user = await _userManager.GetUserAsync(User);
            bool isInRole = await _userManager.IsInRoleAsync(user, "Administrator");


            await RefreshData();           
        }

        public async Task OnPostAsync()
        {
            await RefreshData();
        }
        internal record NomenclatureR(int id, string name, string price);
        public async Task OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await Upload.CopyToAsync(memoryStream);
                var str = Encoding.UTF8.GetString(memoryStream.ToArray());
                var nomenclatures = System.Text.Json.JsonSerializer.Deserialize<NomenclatureR[]>(str);
                foreach (var item in nomenclatures)
                {
                    var nomenclature = new Nomenclature {  Name = item.name, Price = double.Parse(item.price.Replace('.', ',')) };
                    //var n = await _context.Nomenclatures.FirstOrDefaultAsync(d=>d.Name == nomenclature.Name);
                    //if (n != null)
                    //{
                    //    n.Price = nomenclature.Price;
                    //}else
                    //{
                        await _context.AddAsync(nomenclature);
                    //}
                     
                    await _context.SaveChangesAsync();
                }


            }
            await RefreshData();
        }

    }
}
