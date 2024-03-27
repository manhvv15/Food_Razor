using G5Foods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//namespace G5Foods.Pages.Customer.Shop
//{
//	public class IndexModel : PageModel
//	{
//		private readonly G5FoodsContext _context;

//		public IndexModel(G5FoodsContext context)
//		{
//			_context = context;
//		}

//		public IList<Product> Product { get; set; }
//		public IList<Category> Categories { get; set; }
//		public async Task OnGetAsync(string category)
//		{
//			IQueryable<Product> products = _context.Products.Include(p => p.Category);

//			if (!string.IsNullOrEmpty(category))
//			{
//				products = products.Where(p => p.Category.CategoryName == category);
//			}

//			Product = await products.ToListAsync();
//			Categories = await _context.Categories.ToListAsync();
//		}
//	}
//}

namespace G5Foods.Pages.Customer.Shop
{
	public class IndexModel : PageModel
	{
		private readonly G5FoodsContext _context;

		public IndexModel(G5FoodsContext context)
		{
			_context = context;
		}

		public IList<Product> Product { get; set; }
		public IList<Category> Categories { get; set; }

		public async Task OnGetAsync(string category, string productName)
		{
			IQueryable<Product> products = _context.Products.Include(p => p.Category);

			if (!string.IsNullOrEmpty(category))
			{
				products = products.Where(p => p.Category.CategoryName == category);
			}

			if (!string.IsNullOrEmpty(productName))
			{
				products = products.Where(p => p.ProductName.Contains(productName));
			}

			Product = await products.ToListAsync();
			Categories = await _context.Categories.ToListAsync();
		}
	}
}