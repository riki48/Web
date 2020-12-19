using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;

namespace WebApp.Data
{
	public class DBobjects
	{
		public static void Initial(AppContext content)
		{
			


			if (!content.Category.Any())
				content.Category.AddRange (Categories.Select(c => c.Value));
			if(!content.Car.Any())
			{
				content.AddRange(
				new Car()
				{
					
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
					
					Name = "Ford Fiesta",
					ShortDescription = "Тихий и спокойный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/Ford Fiesta.jpg",
					Price = 11000,
					IsFavourite = false,
					Available = true,
					Category = Categories["Обычные автомобили"]
				},

				new Car()
				{
					
					Name = "BMW M3",
					ShortDescription = "Дерзкий и стильный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/bmw.jpg",
					Price = 65000,
					IsFavourite = true,
					Available = true,
					Category = Categories["Обычные автомобили"]
				},

				new Car()
				{
					
					Name = "Mercedes-C",
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
					
					Name = "Nissan Leaf",
					ShortDescription = "Бесшумный и экономный",
					LongDescription = "Удобный автомобиль для городской жизни",
					Img = "/img/tesla.jpg",
					Price = 14000,
					IsFavourite = true,
					Available = true,
					Category = Categories["Обычные автомобили"]
				} );		
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
					foreach (var item in list)
						category.Add(item.CategoryName,item);
					
				}
				return category;
			}
			
		}
	
	}
}
