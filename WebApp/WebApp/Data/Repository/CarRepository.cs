using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Interfaces;
using WebApp.Data.Models;

namespace WebApp.Data.Repository
{
	public class CarRepository: IAllCars
	{
		private readonly AppDBContext appDBContent;

		public CarRepository(AppDBContext appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		public IEnumerable<Car> Cars => appDBContent.Car.Include(c=>c.Category);
		public IEnumerable<Car> GetFavouriteCars => appDBContent.Car.Where(p => p.IsFavourite).Include(f=>f.Category);

		public Car GetObjectCar(int carID) => appDBContent.Car.FirstOrDefault(p => p.ID == carID);
		
	}
}
