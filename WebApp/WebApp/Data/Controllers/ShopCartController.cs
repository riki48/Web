using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Interfaces;
using WebApp.Data.Models;
using WebApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Data.Controllers
{
	public class ShopCartController: Controller
	{
		private readonly IAllCars _carRep;
		private readonly ShopCart _shopCart;

		public ShopCartController(IAllCars carRep,ShopCart shopCart )
		{
			_carRep = carRep;
			_shopCart = shopCart;
		}
		
		public IActionResult Delete(ShopCartViewModel item)
		{
			//List<CartItem> orders = _shopCart.listShopItems;
			
			return Content(item.ShopCart.ShopCartId);

		}

		public ViewResult Index()
		{
			List<CartItem> items = _shopCart.GetShopItems();
			_shopCart.listShopItems = items;
			var obj = new ShopCartViewModel
			{
				ShopCart = _shopCart
			};

			return View(obj);
		}
	
		public RedirectToActionResult AddToCart(int id)
		{
			var item = _carRep.Cars.FirstOrDefault(i=>i.ID==id);
			if (item != null)
				_shopCart.AddToCart(item);
			return RedirectToAction("Index");
		}
	}
}
