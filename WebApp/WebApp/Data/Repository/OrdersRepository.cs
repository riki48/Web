using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Interfaces;
using WebApp.Data.Models;

namespace WebApp.Data.Repository
{
	public class OrdersRepository : IAllOrders
	{
		private readonly AppDBContext appDBContext;

		private readonly ShopCart shopCart;
		public OrdersRepository(AppDBContext appDBContext,ShopCart shopCart)
		{
			this.appDBContext = appDBContext;
			this.shopCart = shopCart;
		}

		public void CreateOrder(Order order)
		{
			order.OrderTime = DateTime.Now;
			appDBContext.Orders.Add(order);

			List<CartItem> items = shopCart.listShopItems;

			foreach (var item in items)
			{
				OrderDetail orderDetail = new OrderDetail()
				{
					CarID = item.Car.ID,
					orderID = order.ID,
					Price = item.Car.Price
				};
				appDBContext.OrderDetails.Add(orderDetail);
			}
			appDBContext.SaveChanges();
		}
	}
}
