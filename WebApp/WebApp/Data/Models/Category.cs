using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Models
{
	public class Category
	{
	    public int ID { get; set; }

		public string CategoryName { get; set; }

		public string Description { get; set; }

		public List<Car> Cars { get; set; }
	}
}
