using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;

namespace WebApp.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Car> FavCars { get; set; }
	}
}
