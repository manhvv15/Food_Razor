using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using G5Foods.Models;

namespace G5Foods.Pages.Admin.ManageOrder
{
    public class IndexModel : PageModel
    {
        private readonly G5Foods.Models.G5FoodsContext _context;

        public IndexModel(G5Foods.Models.G5FoodsContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            using (var db = new G5FoodsContext())
            {
                var orders = db.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.Admin)
                    .Where(x => x.OrderDate != null && x.RequiredDate == null);
                ViewData["orders"] = orders.ToList();
            }
        }

        public async Task OnPostAsync(int OrderId)
        {
            using (var db = new G5FoodsContext())
            {
                var order = db.Orders.FirstOrDefault(x => x.OrderId == OrderId);
                if (order != null)
                {
                    order.RequiredDate = DateTime.Now;
                    await db.SaveChangesAsync();
                }
                var orders = db.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.Admin)
                    .Where(x => x.OrderDate != null && x.RequiredDate.Value.Date <= DateTime.Now.Date);
                ViewData["orders"] = orders.ToList();
            }
        }
    }
}
