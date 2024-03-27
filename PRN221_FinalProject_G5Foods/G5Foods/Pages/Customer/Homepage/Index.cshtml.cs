//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using G5Foods.Models;

//namespace G5Foods.Pages.Customer.Homepage
//{
//    public class IndexModel : PageModel
//    {
//        private readonly G5Foods.Models.G5FoodsContext _context;

//        public IndexModel(G5Foods.Models.G5FoodsContext context)
//        {
//            _context = context;
//        }

//        public IList<Product> Product { get;set; } = default!;

//        public async Task OnGetAsync()
//        {
//            if (_context.Products != null)
//            {
//                Product = await _context.Products
//                .Include(p => p.Category).ToListAsync();
//            }
//        }
//    }
//}


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using G5Foods.Models;
using Microsoft.AspNetCore.Http;

namespace G5Foods.Pages.Customer.Homepage
{
    public class IndexModel : PageModel
    {
        private readonly G5FoodsContext _context;

        public IndexModel(G5FoodsContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;
        public string CustomerName { get; set; }

        public async Task OnGetAsync()
        {
            // Lấy customerId từ session
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            if (customerId.HasValue)
            {
                // Truy xuất thông tin khách hàng từ customerId
                var customer = await _context.Customers.FindAsync(customerId);

                if (customer != null)
                {
                    // Lấy tên của khách hàng
                    CustomerName = customer.CustomerName;
                }
            }

            // Truy xuất danh sách sản phẩm
            Product = await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
