//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using G5Foods.Models;

//namespace G5Foods.Pages.Functions.Customers
//{
//    public class DetailsModel : PageModel
//    {
//        private readonly G5Foods.Models.G5FoodsContext _context;

//        public DetailsModel(G5Foods.Models.G5FoodsContext context)
//        {
//            _context = context;
//        }

//      public Customer Customer { get; set; } = default!; 

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null || _context.Customers == null)
//            {
//                return NotFound();
//            }

//            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
//            if (customer == null)
//            {
//                return NotFound();
//            }
//            else 
//            {
//                Customer = customer;
//            }
//            return Page();
//        }
//    }
//}
