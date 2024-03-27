using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using G5Foods.Models;

namespace G5Foods.Pages.Admin.ManageProduct
{
    public class CreateModel : PageModel
    {
        private readonly G5Foods.Models.G5FoodsContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(G5Foods.Models.G5FoodsContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(IFormFile imageUpload)
        {
            if (!ModelState.IsValid || imageUpload == null || _context.Products == null || Product == null)
            {
                ErrorMessage = "Please upload an image.";
                ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
                return Page();
            }

            // Save the uploaded image to the wwwroot/images folder
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "assets","img","products");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageUpload.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageUpload.CopyToAsync(fileStream);
            }

            // Save other product details to the database
            Product.Image = uniqueFileName; // Save the unique file name to the database
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
