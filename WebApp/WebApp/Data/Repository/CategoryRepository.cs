using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Interfaces;
using WebApp.Data.Models;

namespace WebApp.Data.Repository
{
	public class CategoryRepository : ICarsCategory
	{

		private readonly AppDBContext appDBContent;

		public CategoryRepository(AppDBContext appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		public IEnumerable<Category> AllCategories => appDBContent.Category;
	}
}
