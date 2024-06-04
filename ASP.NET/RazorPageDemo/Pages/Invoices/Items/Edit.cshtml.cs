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

namespace RazorPageDemo.Pages.Invoices.Items
{
    public class EditModel : PageModel
    {
        private readonly RazorPageDemo.Data.CafeDbContext _context;

        public EditModel(RazorPageDemo.Data.CafeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InvoiceDetail InvoiceDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicedetail =  await _context.InvoiceDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (invoicedetail == null)
            {
                return NotFound();
            }
            InvoiceDetail = invoicedetail;
           ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Bayer");
           ViewData["NomenclatureId"] = new SelectList(_context.Nomenclatures, "Id", "Name");
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

            _context.Attach(InvoiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailExists(InvoiceDetail.Id))
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

        private bool InvoiceDetailExists(Guid id)
        {
            return _context.InvoiceDetails.Any(e => e.Id == id);
        }
    }
}
