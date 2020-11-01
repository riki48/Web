using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;

namespace WebApp.Data.Interfaces
{
	public interface IAllCars
	{
		IEnumerable<Car> Cars { get; set; }
		IEnumerable<Car> GetFavouriteCars { get; set; }
		Car GetObjectCar(int carID);
	}
	
} 

