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
					Img = "https://www.tesla.com/content/dam/tesla-site/sx-redesign/img/socialcard/MS.jpg",
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
					Img = "https://www.winnerauto.ua/uploads/gallery_photo/photo/0170/91.jpg",
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
					Img = "https://img.tipcars.com/fotky_velke/33550669_9/2018/E/bmw-m3-top-m-performance-paket.jpg",
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
					Img = "https://img.tipcars.com/fotky_velke/33550669_9/2018/E/bmw-m3-top-m-performance-paket.jpg",
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
					Img = "https://d2t6ms4cjod3h9.cloudfront.net/wp-content/uploads/2018/11/LEAF_Nissan_Energy_Share-source.jpg",
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
