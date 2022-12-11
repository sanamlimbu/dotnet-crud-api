using System;
using Microsoft.EntityFrameworkCore;

namespace dotnet_crud_api.Entities
{
	public class DotNetCrudApiContext : DbContext
	{
		public DotNetCrudApiContext(DbContextOptions<DotNetCrudApiContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Add PostgresSQL extension for UUID generation
			modelBuilder.HasPostgresExtension("uuid-ossp");
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
		}
		public DbSet<Product> Products
		{
			get;
			set;
		}
	}
}

