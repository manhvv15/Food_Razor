//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using G5Foods.Models;

//namespace G5Foods.Pages.Functions.Admins
//{
//    public class CreateModel : PageModel
//    {
//        private readonly G5Foods.Models.G5FoodsContext _context;

//        public CreateModel(G5Foods.Models.G5FoodsContext context)
//        {
//            _context = context;
//        }

//        public IActionResult OnGet()
//        {
//            return Page();
//        }

//        //[BindProperty]
//        //public Admin Admin { get; set; } = default!;
        

//        //// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
//        //public async Task<IActionResult> OnPostAsync()
//        //{
//        //  if (!ModelState.IsValid || _context.Admins == null || Admin == null)
//        //    {
//        //        return Page();
//        //    }

//        //    _context.Admins.Add(Admin);
//        //    await _context.SaveChangesAsync();

//        //    return RedirectToPage("./Index");
//        //}
//    }
//}
