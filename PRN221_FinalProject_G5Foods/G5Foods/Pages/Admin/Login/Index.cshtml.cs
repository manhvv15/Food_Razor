using G5Foods.Models;
using G5Foods.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace G5Foods.Pages.Admin.Login
{
    public class IndexModel : PageModel
    {
        private readonly G5FoodsContext _context;
        public IndexModel(G5FoodsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string AdminEmail { get; set; }

        [BindProperty]
        public string AdminPassword { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(c => c.AdminEmail == AdminEmail && c.AdminPassword == AdminPassword);
            if (admin == null)
            {
                ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return Page();
            }

            HttpContext.Session.SetInt32("AdminId", admin.AdminId);
            return RedirectToPage("/Admin/Dashboard/Index");
        }
    }
}
