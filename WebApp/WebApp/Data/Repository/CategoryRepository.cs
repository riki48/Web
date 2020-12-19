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

		private readonly AppContext appDBContent;

		public CategoryRepository(AppContext appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		public IEnumerable<Category> AllCategories => appDBContent.Category;
	}
}
