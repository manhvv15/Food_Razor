////using G5Foods.Models;
////using Microsoft.AspNetCore.Mvc;
////using Microsoft.AspNetCore.Mvc.RazorPages;
////using Newtonsoft.Json;
////using Microsoft.AspNetCore.Http;

////namespace G5Foods.Pages.Customer.Cart
////{
////    //public class IndexModel : PageModel
////    //{
////    //    private readonly IHttpContextAccessor _httpContextAccessor;

////    //    public IndexModel(IHttpContextAccessor httpContextAccessor)
////    //    {
////    //        _httpContextAccessor = httpContextAccessor;
////    //    }

////    //    private ISession Session => _httpContextAccessor.HttpContext.Session;

////    //    public List<CartItem> GetCart()
////    //    {
////    //        var cart = Session.GetString("Cart");
////    //        return cart == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);
////    //    }

////    //    public void AddToCart(CartItem item)
////    //    {
////    //        var cart = GetCart();
////    //        var existingItem = cart.FirstOrDefault(i => i.Product.ProductId == item.Product.ProductId);
////    //        if (existingItem != null)
////    //        {
////    //            existingItem.Quantity += item.Quantity;
////    //        }
////    //        else
////    //        {
////    //            cart.Add(item);
////    //        }
////    //        Session.SetString("Cart", JsonConvert.SerializeObject(cart));
////    //    }

////    //    public void ClearCart()
////    //    {
////    //        Session.Remove("Cart");
////    //    }
////    //}

////	public class IndexModel : PageModel
////	{
////		private readonly G5FoodsContext _db;

////		public IndexModel(G5FoodsContext db)
////		{
////			_db = db;
////		}

////		[BindProperty]
////		public List<CartItem> cartItems { get; set; } = new List<CartItem>();
////		[BindProperty]
////		public List<Product> products { get; set; } = default!;
////		[BindProperty]
////		public decimal totalPrice { get; set; } = 0;
////		public async Task<IActionResult> OnGet()
////		{
////			//if (HttpContext.Session.GetString("Account") == null)
////			//{
////			//    return RedirectToPage("Login");
////			//}

////			var cartJson = HttpContext.Session.GetString("cart");


////			cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson).OrderBy(x => x.ProductId).ToList();
////			foreach (var i in cartItems)
////			{
////				totalPrice += (decimal)(i.Quantity * i.UnitPrice);
////			}
////			List<int> productIds = cartItems.Select(item => item.ProductId).ToList<int?>().ConvertAll<int>(x => x.GetValueOrDefault());
////			List<Product> product = _db.Products.Where(product => productIds.Contains(product.ProductId)).ToList();
////			products = product;
////			return Page();
////		}


////		public async Task<IActionResult> OnGetDelete(int? id)
////		{
////			var cartJson = HttpContext.Session.GetString("cart");
////			if (cartJson != null)
////			{
////				cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson).OrderBy(x => x.ProductId).ToList();
////				CartItem a = cartItems.Find(x => x.ProductId == id);
////				cartItems.Remove(a);
////				HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartItems));

////				List<int> productIds = cartItems.Select(item => item.ProductId).ToList<int?>().ConvertAll<int>(x => x.GetValueOrDefault());
////				List<Product> product = _db.Products.Where(product => productIds.Contains(product.ProductId)).ToList();
////				products = product;
////				return RedirectToPage("Cart");
////			}
////			else
////			{
////				return RedirectToPage("Cart");
////			}



////		}
////		public async Task<IActionResult> OnGetMinus(int? id)
////		{
////			var cartJson = HttpContext.Session.GetString("cart");
////			if (cartJson != null)
////			{
////				cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson).OrderBy(x => x.ProductId).ToList();
////				CartItem a = cartItems.Find(x => x.ProductId == id);
////				if (a.Quantity > 1)
////				{
////					cartItems.FirstOrDefault(x => x.ProductId == id).Quantity--;

////				}
////				else
////				{
////					return RedirectToPage("Cart");
////				}

////				HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartItems));

////				List<int> productIds = cartItems.Select(item => item.ProductId).ToList<int?>().ConvertAll<int>(x => x.GetValueOrDefault());
////				List<Product> product = _db.Products.Where(product => productIds.Contains(product.ProductId)).ToList();
////				products = product;
////				return RedirectToPage("Cart");
////			}
////			else
////			{
////				return RedirectToPage("Cart");
////			}



////		}
////		public async Task<IActionResult> OnGetAdd(int? id)
////		{
////			var cartJson = HttpContext.Session.GetString("cart");
////			if (cartJson != null)
////			{
////				cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson).OrderBy(x => x.ProductId).ToList();
////				CartItem a = cartItems.Find(x => x.ProductId == id);

////				var productrr = _db.Products.FirstOrDefault(x => x.ProductId == id);
////				//if (a.Quantity + 1 > productrr.UnitsInStock)
////				//{
////				//	TempData["msg"] = "The quantity your buy  is more than in stock";
////				//	return RedirectToPage("Cart");
////				//}
////				cartItems.FirstOrDefault(x => x.ProductId == id).Quantity++;



////				HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartItems));

////				List<int> productIds = cartItems.Select(item => item.ProductId).ToList<int?>().ConvertAll<int>(x => x.GetValueOrDefault());
////				List<Product> product = _db.Products.Where(product => productIds.Contains(product.ProductId)).ToList();
////				products = product;
////				return RedirectToPage("Cart");
////			}
////			else
////			{
////				return RedirectToPage("Cart");
////			}
////		}
////	}
////}


//using G5Foods.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using G5Foods.Models;
//using System.Security.Cryptography;
//using System.Text.Json;

//namespace G5Foods.Pages.Customer.Cart
//{
//	public class IndexModel : PageModel
//	{
//		private readonly G5FoodsContext _db;

//		public IndexModel(G5FoodsContext db)
//		{
//			_db = db;
//		}

//		[BindProperty]
//		public List<CartItem> cartItems { get; set; } = new List<CartItem>();
//		[BindProperty]
//		public List<Product> products { get; set; } = default!;
//		[BindProperty]
//		public decimal totalPrice { get; set; } = 0;
//		public async Task<IActionResult> OnGet()
//		{
//			//if (HttpContext.Session.GetString("Account") == null)
//			//{
//			//    return RedirectToPage("Login");
//			//}

//			var cartJson = HttpContext.Session.GetString("cart");


//			cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson).OrderBy(x => x.ProductId).ToList();
//			foreach (var i in cartItems)
//			{
//				totalPrice += (decimal)(i.Quantity * i.UnitPrice);
//			}
//			List<int> productIds = cartItems.Select(item => item.ProductId).ToList<int?>().ConvertAll<int>(x => x.GetValueOrDefault());
//			List<Product> product = _db.Products.Where(product => productIds.Contains(product.ProductId)).ToList();
//			products = product;
//			return Page();
//		}


//		public async Task<IActionResult> OnGetDelete(int? id)
//		{
//			var cartJson = HttpContext.Session.GetString("cart");
//			if (cartJson != null)
//			{
//				cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson).OrderBy(x => x.ProductId).ToList();
//				CartItem a = cartItems.Find(x => x.ProductId == id);
//				cartItems.Remove(a);
//				HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartItems));

//				List<int> productIds = cartItems.Select(item => item.ProductId).ToList<int?>().ConvertAll<int>(x => x.GetValueOrDefault());
//				List<Product> product = _db.Products.Where(product => productIds.Contains(product.ProductId)).ToList();
//				products = product;
//				return RedirectToPage("Cart");
//			}
//			else
//			{
//				return RedirectToPage("Cart");
//			}



//		}
//		public async Task<IActionResult> OnGetMinus(int? id)
//		{
//			var cartJson = HttpContext.Session.GetString("cart");
//			if (cartJson != null)
//			{
//				cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson).OrderBy(x => x.ProductId).ToList();
//				CartItem a = cartItems.Find(x => x.ProductId == id);
//				if (a.Quantity > 1)
//				{
//					cartItems.FirstOrDefault(x => x.ProductId == id).Quantity--;

//				}
//				else
//				{
//					return RedirectToPage("Cart");
//				}

//				HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartItems));

//				List<int> productIds = cartItems.Select(item => item.ProductId).ToList<int?>().ConvertAll<int>(x => x.GetValueOrDefault());
//				List<Product> product = _db.Products.Where(product => productIds.Contains(product.ProductId)).ToList();
//				products = product;
//				return RedirectToPage("Cart");
//			}
//			else
//			{
//				return RedirectToPage("Cart");
//			}



//		}
//		public async Task<IActionResult> OnGetAdd(int? id)
//		{
//			var cartJson = HttpContext.Session.GetString("cart");
//			if (cartJson != null)
//			{
//				cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson).OrderBy(x => x.ProductId).ToList();
//				CartItem a = cartItems.Find(x => x.ProductId == id);

//				var productrr = _db.Products.FirstOrDefault(x => x.ProductId == id);
//				//if (a.Quantity + 1 > productrr.UnitsInStock)
//				//{
//				//	TempData["msg"] = "The quantity your buy  is more than in stock";
//				//	return RedirectToPage("Cart");
//				//}
//				cartItems.FirstOrDefault(x => x.ProductId == id).Quantity++;



//				HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartItems));

//				List<int> productIds = cartItems.Select(item => item.ProductId).ToList<int?>().ConvertAll<int>(x => x.GetValueOrDefault());
//				List<Product> product = _db.Products.Where(product => productIds.Contains(product.ProductId)).ToList();
//				products = product;
//				return RedirectToPage("Cart");
//			}
//			else
//			{
//				return RedirectToPage("Cart");
//			}
//		}
//	}
//}
