using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cafe.Models;
using RazorPageDemo.Data;

namespace RazorPageDemo.Pages.Invoices.Items
{
    public class CreateModel : PageModel
    {
        private readonly RazorPageDemo.Data.CafeDbContext _context;

        public CreateModel(RazorPageDemo.Data.CafeDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Bayer");
        ViewData["NomenclatureId"] = new SelectList(_context.Nomenclatures, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public InvoiceDetail InvoiceDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InvoiceDetails.Add(InvoiceDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
