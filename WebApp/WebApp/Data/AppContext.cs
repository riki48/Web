using AuthTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;

namespace WebApp.Data
{
	public class AppContext : DbContext
	{
		public AppContext(DbContextOptions<AppContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }
		public DbSet<Car> Car {get;set;}

		public DbSet<Category> Category { get; set; }

		public DbSet<CartItem> CartItem { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			string adminRoleName = "admin";
			string userRoleName = "user";

			string adminEmail = "admin@mail.ru";
			string adminPassword = "123456";

			// добавляем роли
			Role adminRole = new Role { Id = 1, Name = adminRoleName };
			Role userRole = new Role { Id = 2, Name = userRoleName };
			User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

			modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
			modelBuilder.Entity<User>().HasData(new User[] { adminUser });
			base.OnModelCreating(modelBuilder);
		}
	}
}
