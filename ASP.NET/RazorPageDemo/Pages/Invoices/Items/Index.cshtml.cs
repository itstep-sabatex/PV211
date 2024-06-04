using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPageDemo.Data;

namespace RazorPageDemo.Pages.Invoices.Items
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageDemo.Data.CafeDbContext _context;

        public IndexModel(RazorPageDemo.Data.CafeDbContext context)
        {
            _context = context;
        }

        public IList<InvoiceDetail> InvoiceDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            InvoiceDetail = await _context.InvoiceDetails
                .Include(i => i.Invoice)
                .Include(i => i.Nomenclature).ToListAsync();
        }
    }
}
