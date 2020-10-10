﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Models
{
	public class Car
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public string ShortDescription {get;set;}

		public string LongDescription { get; set; }

		public string Img { get; set; } // url картинки

		public ushort Price { get; set; }

		public bool IsFavourite { get; set; }

		public bool Available { get; set; }

		public int CategoryID { get; set; }

		public virtual Category Category { get; set; }
	}
}
