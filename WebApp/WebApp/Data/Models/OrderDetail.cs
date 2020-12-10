using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Models
{
	public class OrderDetail
	{
		public int id { get; set; }

		public int orderID { get; set; }

		public int CarID { get; set; }

		public uint Price { get; set; }

		public virtual Car Car { get; set; }

		public virtual Order Order { get; set; }

	}
}
