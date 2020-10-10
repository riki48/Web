using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;

namespace WebApp.Data.Interfaces
{
	public interface ICarsCategory
	{
		IEnumerable<Category> AllCategories { get; }
	}
}
