using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Interfaces;
using WebApp.Data.Models;

namespace WebApp.Data.Mocks
{
	public class MockCategory : ICarsCategory
	{
		public IEnumerable<Category> AllCategories
		{
			get
			{
				return new List<Category>
				{
					new Category{CategoryName = "Электромобили",Description = "Экологически чистый транспорт"},
					new Category{CategoryName = "Обычные автомобили", Description = "Обычные авто"}
				};
			}
		}
	}
}
