using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using G5Foods.Models;

namespace G5Foods.Pages.Customer.MyOrder
{
    public class IndexModel : PageModel
    {
        private readonly G5FoodsContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(G5FoodsContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<Order> Orders { get; set; }
        public IList<OrderDetail> OrderDetail { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            if (customerId.HasValue)
            {
                Orders = await _context.Orders
                    .Include(o => o.AddressNavigation)
                    .Include(o => o.Admin)
                    .Include(o => o.Customer)
                    .Where(o => o.CustomerId == customerId)
                    .ToListAsync();

                OrderDetail = await _context.OrderDetails
                    .Include(o => o.Order)
                    .Include(o => o.Product).ToListAsync();
            }
        }
    }
}
