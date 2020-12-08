using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;

namespace WebApp.Data
{
	public class DBObjects
	{
		public static void Initial(AppDBContext content)
		{
				

			if (!content.Category.Any())
			{
				content.Category.AddRange(Categories.Select(c => c.Value));
			}
			if (!content.Car.Any())
			{
				content.AddRange(

				new Car()
				{
					//ID = 1,
					Name = "Tesla Model 5",
					ShortDescription = "Быстрый автомобиль",
					LongDescription = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					Img = "/img/tesla.jpg",
					Price = 45000,
					IsFavourite = true,
					Available = true,
					Category = Categories["Электромобили"]
				},

				new Car()
				{
					//ID = 2,
					Name = "Ford Fiesta",
					ShortDescription = "Тихий и спокойный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 11000,
					IsFavourite = false,
					Available = true,
					Category = Categories["Обычные автомобили"]
				},

				new Car()
				{
					//ID = 3,
					Name = "BMW M3",
					ShortDescription = "Дерзкий и стильный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 65000,
					IsFavourite = true,
					Available = true,
					Category = Categories["Обычные автомобили"]
				},

				new Car()
				{
					//ID = 4,
					Name = "Mercedes C class",
					ShortDescription = "Уютный и большой",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 40000,
					IsFavourite = false,
					Available = false,
					Category = Categories["Обычные автомобили"]
				},
				new Car()
				{
					//ID = 5,		
					Name = "Nissan Leaf",
					ShortDescription = "Бесшумный и экономный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 14000,
					IsFavourite = true,
					Available = true,
					Category = Categories["Обычные автомобили"]
				}
				);
			}
			content.SaveChanges();
		}
		private static Dictionary<string, Category> category;
		public static Dictionary<string, Category> Categories
		{
			get
			{
				if(category==null)
				{
					var list = new Category[]
					{
						new Category{CategoryName = "Электромобили",Description = "Экологически чистый транспорт"},
						new Category{CategoryName = "Обычные автомобили", Description = "Обычные авто"}
					};
					category = new Dictionary<string, Category>();
					foreach (Category el in list)
					{
						category.Add(el.CategoryName, el);
					}
				}
				return category;
			}
		}
	}
}
