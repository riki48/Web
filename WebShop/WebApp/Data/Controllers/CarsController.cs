using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data.Interfaces;

namespace WebApp.Data.Controllers
{
	public class CarsController : Controller
	{
		private readonly IAllCars _allCars;
		private readonly ICarsCategory _allCategories;

		public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategory)
		{
			_allCars = iAllCars;
			_allCategories = iCarsCategory;
		}
		public ViewResult List()
		{
			var cars = _allCars.Cars;
			return View(); 
		}
	}
}  