using G5Foods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace G5Foods.Pages.Admin.Report
{
    public class IndexModel : PageModel
    {
        public void OnGet(DateTime? DateFrom, DateTime? DateTo)
        {
            if (DateFrom  == null)
            {
                DateFrom = DateTime.Now.AddDays(-30).Date;
            }
            DateFrom = DateFrom.Value.Date;

            if (DateTo == null)
            {
                DateTo = DateTime.Now.Date;
            }
            DateFrom = DateFrom.Value.Date;

            using (var db = new G5FoodsContext())
            {
                var orders = db.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.Admin)
                    .Where(x => x.OrderDate != null && x.OrderDate.Value.Date >= DateFrom && x.OrderDate.Value.Date <= DateTo);
                ViewData["orders"] = orders.ToList();
                ViewData["DateFrom"] = DateFrom.Value.ToString("dd/MM/yyyy");
                ViewData["DateTo"] = DateTo.Value.ToString("dd/MM/yyyy");
            }
        }
    }
}
