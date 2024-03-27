//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using G5Foods.Models;

//namespace G5Foods.Pages.Functions.Admins
//{
//    public class DetailsModel : PageModel
//    {
//        private readonly G5Foods.Models.G5FoodsContext _context;

//        public DetailsModel(G5Foods.Models.G5FoodsContext context)
//        {
//            _context = context;
//        }

//      public Admin Admin { get; set; } = default!; 

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null || _context.Admins == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admins.FirstOrDefaultAsync(m => m.AdminId == id);
//            if (admin == null)
//            {
//                return NotFound();
//            }
//            else 
//            {
//                Admin = admin;
//            }
//            return Page();
//        }
//    }
//}
