using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using G5Foods.Models;
using System.Text.Json;

namespace G5Foods.Pages.Customer.Shop
{
	public class DetailsModel : PageModel
	{
		private readonly G5Foods.Models.G5FoodsContext _context;

		public DetailsModel(G5Foods.Models.G5FoodsContext context)
		{
			_context = context;
		}

		public Product Product { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}

			var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(m => m.ProductId == id);
			if (product == null)
			{
				return NotFound();
			}
			else
			{
				Product = product;
			}
			return Page();
		}

		public async Task<IActionResult> OnGetAddToCart(int? pid, string returnUrl)
		{
			var cartJson = HttpContext.Session.GetString("cart");
			var cart = string.IsNullOrEmpty(cartJson) ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(cartJson);
			var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == pid);

			if (product != null)
			{
				var existingItem = cart.FirstOrDefault(x => x.ProductId == pid);
				if (existingItem != null)
				{
					existingItem.Quantity++;
				}
				else
				{
					cart.Add(new CartItem
					{
						ProductId = pid,
						ProductName = product.ProductName,
						UnitPrice = product.UnitPrice,
						Quantity = 1
					});
				}

				HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));
				TempData["CartMessage"] = $"{product.ProductName} has been added to your cart.";
			}
			else
			{
				TempData["ErrorMessage"] = "Product not found.";
			}
			return Redirect(returnUrl);
		}

		public async Task<IActionResult> OnPostAsync(int? pid, string returnUrl)
		{
			if (pid == null)
			{
				return NotFound();
			}

			var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == pid);
			if (product == null)
			{
				return NotFound();
			}

			var cartJson = HttpContext.Session.GetString("cart");
			var cart = string.IsNullOrEmpty(cartJson) ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(cartJson);

			var existingItem = cart.FirstOrDefault(x => x.ProductId == pid);
			if (existingItem != null)
			{
				existingItem.Quantity++;
			}
			else
			{
				cart.Add(new CartItem
				{
					ProductId = pid,
					ProductName = product.ProductName,
					UnitPrice = product.UnitPrice,
					Quantity = 1
				});
			}

			HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));
			TempData["CartMessage"] = $"{product.ProductName} has been added to your cart.";

			return Redirect("/customer/shop");
		}
	}
}
