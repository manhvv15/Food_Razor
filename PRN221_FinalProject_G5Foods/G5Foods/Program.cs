using Microsoft.EntityFrameworkCore;
using G5Foods.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register HttpContextAccessor
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<G5FoodsContext>(options => options.UseSqlServer(
	builder.Configuration.GetConnectionString("G5DB")
));

builder.Services.AddSession(x =>
{
	x.IdleTimeout = TimeSpan.FromMinutes(10);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure routing to start from "Customer/Index"
app.UseEndpoints(endpoints =>
{
	endpoints.MapRazorPages();
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Customer}/{action=Index}/{id?}");
});

app.Run();
