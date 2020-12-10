using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Models
{
	public class UserContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public UserContext(DbContextOptions<UserContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}