using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;

namespace WebApp.ViewModels
{
	public class CarsListViewModel
	{
		public IEnumerable<Car> AllCars {get;set;}

		public string CurrentCategory { get; set; }			
	}
}
