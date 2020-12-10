using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Models
{
	public class ShopCart
	{
		private readonly AppDBContext appDBContext;

		public ShopCart(AppDBContext appDBContext)
		{
			this.appDBContext = appDBContext;
		}
		public string ShopCartId { get; set; }

		public List<CartItem> listShopItems { get; set; }

		public static ShopCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			AppDBContext context = services.GetService<AppDBContext>();
			string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
			session.SetString("CartId", shopCartId);

			return new ShopCart(context) { ShopCartId = shopCartId };
		}

		public void AddToCart(Car car)
		{
			appDBContext.CartItem.Add(new CartItem
			{
				ShopCartId = ShopCartId,
				Car = car,
				Price = car.Price

			});
			appDBContext.SaveChanges();
		}

		public List<CartItem> GetShopItems()
		{
			return appDBContext.CartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
		}
	}
}
