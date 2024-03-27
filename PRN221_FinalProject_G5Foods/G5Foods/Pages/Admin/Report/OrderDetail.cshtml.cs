using G5Foods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace G5Foods.Pages.Admin.Report
{
    public class OrderDetailModel : PageModel
    {
        public void OnGet(int OrderId)
        {
            using (var db = new G5FoodsContext())
            {
                var order = db.Orders
                    .Include(x => x.OrderDetails)!
                    .ThenInclude(x => x.Product)
                    .FirstOrDefault(x => x.OrderId == OrderId);
                ViewData["order"] = order;
            }
        }
    }
}
