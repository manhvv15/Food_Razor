using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using G5Foods.Models;

namespace G5Foods.Pages.Admin.ManageUser
{
    public class DeleteModel : PageModel
    {
        private readonly G5Foods.Models.G5FoodsContext _context;

        public DeleteModel(G5Foods.Models.G5FoodsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public G5Foods.Models.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }

            // Kiểm tra xem khách hàng có các đơn đặt hàng không
            var orders = await _context.Orders.Where(o => o.CustomerId == Customer.CustomerId).ToListAsync();
            if (orders.Any())
            {
                // Nếu có đơn đặt hàng, xóa chúng trước
                _context.Orders.RemoveRange(orders);
            }

            // Sau đó mới xóa khách hàng
            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
