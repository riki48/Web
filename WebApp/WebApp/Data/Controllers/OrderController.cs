using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Interfaces;
using WebApp.Data.Models;

namespace WebApp.Data.Controllers
{
	public class OrderController: Controller
	{
		private readonly IAllOrders AllOrders;

		private readonly ShopCart shopCart;
		public OrderController(IAllOrders AllOrders, ShopCart shopCart)
		{
			this.AllOrders = AllOrders;
			this.shopCart = shopCart;
		}
		[HttpGet]
		public IActionResult Checkout()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			shopCart.listShopItems = shopCart.GetShopItems();
			if (shopCart.listShopItems.Count == 0)
			{
				ModelState.AddModelError("","Нет товаров");
			}
			if (ModelState.IsValid)
			{
				AllOrders.CreateOrder(order);
				return RedirectToAction("Complete");
			}
			return View(order);
		}
		public IActionResult Complete()
		{
			ViewBag.Message = "Заказ успешно обработан";
			return View();
		}
	}
}
