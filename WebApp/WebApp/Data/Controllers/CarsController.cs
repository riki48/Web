using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data.Interfaces;
using WebApp.Data.Mocks;
using WebApp.ViewModels;
using Npgsql;
using WebApp.Data.Models;

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

		[Route("Cars/List")]
		[Route("Cars/List/{category}")]
		public ViewResult List(string category)
		{
			string _category = category;
			IEnumerable<Car> Cars = null;
			string CurrentCategory = "";
			if (string.IsNullOrEmpty(category))
				Cars = _allCars.Cars.OrderBy(c => c.ID);
			else
			{
				switch (category)
				{
					case "electro":
						Cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Электромобили")).OrderBy(c => c.ID);
						CurrentCategory = "Электромобили";
						break;
					case "combustion":
						Cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Обычные автомобили")).OrderBy(c => c.ID);
						CurrentCategory = "Обычные автомобили";
						break;
				}
						
			}
			var CarObj = new CarsListViewModel
			{
				AllCars = Cars,
				CurrentCategory = CurrentCategory
			};

			ViewBag.Title = "Автомобили";
			//CarsListViewModel obj = new CarsListViewModel();
			//obj.AllCars = _allCars.Cars;
			//obj.CurrentCategory = "Auto";
			//return View(obj); 
			return View(CarObj);
				
		}
		
		
	}
} 