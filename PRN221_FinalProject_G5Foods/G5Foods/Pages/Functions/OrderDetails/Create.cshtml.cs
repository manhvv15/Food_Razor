using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using G5Foods.Models;

namespace G5Foods.Pages.Functions.OrderDetails
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
        ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
        ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OrderDetails == null || OrderDetail == null)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
