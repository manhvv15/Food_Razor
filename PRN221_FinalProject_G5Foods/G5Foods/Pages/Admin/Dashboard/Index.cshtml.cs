using G5Foods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace G5Foods.Admin.Dashboard
{
    public class IndexModel : PageModel
    {

        private readonly G5FoodsContext _context;
        [BindProperty(SupportsGet = true)]
        public int SumProduct { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? sumMonney { get; set; }
        [BindProperty(SupportsGet = true)]
        public int sumCustomer { get; set; }
        public IndexModel(G5FoodsContext context)
        {
            _context = context;

        }
        public void OnGet()
        {
            var listProduct = _context.OrderDetails.ToList();
            SumProduct = listProduct.Count();
            sumMonney = listProduct.Sum(e => e.UnitPrice * e.Quantity);
            sumCustomer = _context.Customers.ToList().Count;

        }
    }
}
