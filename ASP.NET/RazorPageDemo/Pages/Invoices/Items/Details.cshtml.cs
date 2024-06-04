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
    public class DetailsModel : PageModel
    {
        private readonly RazorPageDemo.Data.CafeDbContext _context;

        public DetailsModel(RazorPageDemo.Data.CafeDbContext context)
        {
            _context = context;
        }

        public InvoiceDetail InvoiceDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicedetail = await _context.InvoiceDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (invoicedetail == null)
            {
                return NotFound();
            }
            else
            {
                InvoiceDetail = invoicedetail;
            }
            return Page();
        }
    }
}
