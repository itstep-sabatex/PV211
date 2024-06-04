using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPageDemo.Data;

namespace RazorPageDemo.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly RazorPageDemo.Data.CafeDbContext _context;

        public EditModel(RazorPageDemo.Data.CafeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Invoice Invoice { get; set; } = default!;
        [BindProperty]
        public bool IsNew { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                IsNew = true;
                Invoice = new Invoice { Id = Guid.NewGuid() };
                return Page();
            }

            var invoice =  await _context.Invoices.FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }
            Invoice = invoice;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (IsNew)
            {
                _context.Invoices.Add(Invoice);
            }
            else
            {
                _context.Attach(Invoice).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(Invoice.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InvoiceExists(Guid id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
