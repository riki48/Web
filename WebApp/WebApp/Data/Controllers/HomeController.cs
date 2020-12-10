using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Interfaces;
using WebApp.Data.Models;
using WebApp.ViewModels;

namespace WebApp.Data.Controllers
{
	public class HomeController : Controller
	{
		private readonly IAllCars _carRep;

		public HomeController(IAllCars carRep)
		{
			_carRep = carRep;
		}
		public ViewResult Index()
		{
			var favCars = new HomeViewModel
			{
				FavCars = _carRep.GetFavouriteCars
			};
			return View(favCars);
		}
	}
}
