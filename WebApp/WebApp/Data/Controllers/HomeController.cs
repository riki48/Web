﻿using Microsoft.AspNetCore.Authorization;
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

		[Authorize(Roles = "admin, user")]
		public ViewResult Index()
		{
			var favCars = new HomeViewModel
			{
				FavCars = _carRep.GetFavouriteCars
			};
			return View(favCars);
		}
		//[Authorize(Roles = "admin")]
		public IActionResult Secret()
		{
			return Content("Secret FaNkTiOn");
		}
	}
}
