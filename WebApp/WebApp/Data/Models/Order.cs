using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Models
{
	public class Order
	{
		[BindNever]
		public int ID { get; set; }

		[Display(Name="Имя")]
		[Required]
		[StringLength(25)]
		public string Name { get; set; }
		[StringLength(25)]
		[Display(Name = "Фамилия")]
		public string Surname { get; set; }
		[StringLength(50)]
		[Display(Name = "Адрес")]
		public string Adress { get; set; }

		[StringLength(12)]
		[Required(ErrorMessage ="Неверно указан номер")]
		[Display(Name = "Номер Телефона")]
		public string Phone { get; set; }

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string email { get; set; }
		[BindNever]
		[ScaffoldColumn(false)]
		public DateTime OrderTime { get; set; }

		public List<OrderDetail> OrderDetails { get; set; }
	}
}
