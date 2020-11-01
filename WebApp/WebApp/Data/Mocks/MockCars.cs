using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Interfaces;
using WebApp.Data.Models;

namespace WebApp.Data.Mocks
{
	public class MockCars : IAllCars
	{
		private readonly ICarsCategory _CarsCategory = new MockCategory();

		public IEnumerable<Car> Cars
		{
			get
			{
				return new List<Car> {
				new Car()
				{
					ID = 1,
					Name = "Tesla Model 5",
					ShortDescription = "Быстрый автомобиль",
					LongDescription = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					Img = "/img/tesla.jpg",
					Price = 45000,
					IsFavourite = true,
					Available = true,
					Category = _CarsCategory.AllCategories.First(f=> f.CategoryName.Equals("Обычные автомобили"))
				},

				new Car()
				{
					ID = 2,
					Name = "Ford Fiesta",
					ShortDescription = "Тихий и спокойный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 11000,
					IsFavourite = false,
					Available = true,
					Category = _CarsCategory.AllCategories.First(f=> f.CategoryName.Equals("Обычные автомобили"))
				},

				new Car()
				{
					ID = 3,
					Name = "BMW M3",
					ShortDescription = "Дерзкий и стильный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 65000,
					IsFavourite = true,
					Available = true,
					Category = _CarsCategory.AllCategories.First(f => f.CategoryName.Equals("Обычные автомобили"))
				},

				new Car()
				{
					ID = 4,
					Name = "Mercedes C class",
					ShortDescription = "Уютный и большой",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 40000,
					IsFavourite = false,
					Available = false,
					Category = _CarsCategory.AllCategories.First(f=> f.CategoryName.Equals("Обычные автомобили"))
				},

				new Car()
				{
					ID = 5,
					Name = "Nissan Leaf",
					ShortDescription = "Бесшумный и экономный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 14000,
					IsFavourite = true,
					Available = true,
					Category = _CarsCategory.AllCategories.First(f => f.CategoryName.Equals("Обычные автомобили"))
				}
			};
		}
			set
			{
				throw new NotImplementedException();
			}
			
		}
		public IEnumerable<Car> GetFavouriteCars { get ; set ; }
	

		public Car GetObjectCar(int carID)
		{
			throw new NotImplementedException();
		}
	}
}
