using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPageDemo.Data;

namespace RazorPageDemo.Pages.Nomenclatures
{
    public class IndexModel : PageModel //Nomenclatures/Index
    {
        private readonly RazorPageDemo.Data.CafeDbContext _context;
        [BindProperty(SupportsGet =true)]
        public string Filter { get; set; }=string.Empty;

        public IndexModel(RazorPageDemo.Data.CafeDbContext context)
        {
            _context = context;
        }

        public IList<Nomenclature> Nomenclature { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Nomenclature = await _context.Nomenclatures.Where(s => s.Name.Contains(Filter)).ToListAsync();
        }

        public async Task OnPostAsync()
        {
            Nomenclature = await _context.Nomenclatures.Where(s=>s.Name.Contains(Filter)).ToListAsync();
        }

    }
}
