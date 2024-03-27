using G5Foods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Text.Json;

namespace G5Foods.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly G5FoodsContext _dbContext;
        [BindProperty]
        public Order order { get; set; } = new Order();
        [BindProperty]
        public decimal? totalPrice { get; set; } = 0;

        // Thêm một thuộc tính mới để lưu trữ danh sách các quốc gia
        public List<Address> Countries { get; set; } = new List<Address>();

        public CheckoutModel(G5FoodsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnGet(decimal? totalPrice)
        {
            var cartItems = HttpContext.Session.GetString("cart");
            this.totalPrice = totalPrice;

            order.AdminId = 1;
            Countries = await GetCountries();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            string cart = HttpContext.Session.GetString("cart");
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            if (!customerId.HasValue)
            {
                // Không thể tạo đơn hàng nếu không có thông tin khách hàng
                return RedirectToPage("/Error");
            }

            List<CartItem> cartItems = JsonSerializer.Deserialize<List<CartItem>>(cart);
            if (order != null)
            {
                order.CustomerId = customerId.Value; // Sử dụng customerId từ session
                order.OrderDate = DateTime.Now;
                order.OrderId = 0;
                _dbContext.Orders.Add(order);
            }

            try
            {
                int i = await _dbContext.SaveChangesAsync();
                if (i > 0)
                {
                    int id = _dbContext.Orders.OrderByDescending(x => x.OrderId).FirstOrDefault().OrderId;
                    List<OrderDetail> orderDetails = new List<OrderDetail>();
                    foreach (var c in cartItems)
                    {
                        orderDetails.Add(new OrderDetail { OrderId = id, ProductId = c.ProductId.Value, Quantity = (short)c.Quantity.Value, UnitPrice = (int?)c.UnitPrice.Value });
                    }

                    _dbContext.OrderDetails.AddRange(orderDetails);
                    int a = await _dbContext.SaveChangesAsync();
                    if (a > 0)
                    {
                        // Cập nhật số lượng hàng tồn kho nếu cần
                        // ...

                        return RedirectToPage("/Index");
                    }
                }

                // Trả về trang hiện tại nếu có lỗi xảy ra hoặc không thành công
                return Page();
            }
            catch
            {
                // Trả về trang hiện tại nếu có lỗi xảy ra
                return Page();
            }
        }

        // Phương thức để lấy danh sách các quốc gia từ cơ sở dữ liệu
        private async Task<List<Address>> GetCountries()
        {
            // Thực hiện truy vấn để lấy danh sách các quốc gia
            var countries = await _dbContext.Addresses
                .Where(a => a.Country != null) // Lọc các địa chỉ có thông tin quốc gia
                .OrderBy(a => a.Country) // Sắp xếp theo tên quốc gia
                .ToListAsync();

            return countries;
        }

    }
}
