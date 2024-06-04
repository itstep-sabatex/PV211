using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPageDemo.Data;

namespace RazorPageDemo.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPageDemo.Data.CafeDbContext _context;

        public DeleteModel(RazorPageDemo.Data.CafeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Invoice Invoice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FirstOrDefaultAsync(m => m.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }
            else
            {
                Invoice = invoice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                Invoice = invoice;
                _context.Invoices.Remove(Invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
