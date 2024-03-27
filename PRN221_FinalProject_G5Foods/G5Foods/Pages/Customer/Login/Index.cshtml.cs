using G5Foods.Models;
using G5Foods.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace G5Foods.Pages.Customer.Login
{
    public class IndexModel : PageModel
    {
        private readonly G5FoodsContext _context;
        public IndexModel(G5FoodsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == Email && c.Password == Password);
            if (customer == null)
            {
                return Page();
            }
            
            HttpContext.Session.SetInt32("CustomerId", customer.CustomerId);
            return RedirectToPage("/Customer/Homepage/Index");
        }
    }
}
