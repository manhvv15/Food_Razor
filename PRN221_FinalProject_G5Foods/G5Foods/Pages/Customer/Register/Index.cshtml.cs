using G5Foods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using G5Foods.Models;

namespace G5Foods.Pages.Customer.Register
{
    public class IndexModel : PageModel
    {
        private readonly G5FoodsContext _context;

        public IndexModel(G5FoodsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerRegisterModel Input { get; set; }

        public class CustomerRegisterModel
        {
            [Required]
            [Display(Name = "Name")]
            public string CustomerName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customer = new G5Foods.Models.Customer
            {
                CustomerName = Input.CustomerName,
                Email = Input.Email,
                Password = Input.Password
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Redirect to login page after registration
            return RedirectToPage("/customer/login/index");
        }
    }
}
