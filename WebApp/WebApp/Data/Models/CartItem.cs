﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Models
{
	public class CartItem
	{
		public int ID { get; set; }
		public Car Car { get; set; }
		public uint Price { get; set; }
        public string ShopCartId { get; set; }
	}
}
