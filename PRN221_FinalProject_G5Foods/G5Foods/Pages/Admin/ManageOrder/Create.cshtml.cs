using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using G5Foods.Models;

namespace G5Foods.Pages.Admin.ManageOrder
{
    public class CreateModel : PageModel
    {
        private readonly G5Foods.Models.G5FoodsContext _context;

        public CreateModel(G5Foods.Models.G5FoodsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Address"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
        ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId");
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Orders == null || Order == null)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
