using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using EF.Core.Subqueries.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace EF.Core.Subqueries
{
	public class MyDbContext : DbContext
	{
		private readonly string _connectionString;

		public MyDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder
				.UseMySql(_connectionString,
					mySqlOptionsAction => { mySqlOptionsAction.ServerVersion(new Version(10, 2), ServerType.MariaDb); });

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ParentEntity>(root =>
			{
				root.ToTable("parent");

				root.HasMany(x => x.ChildEntities)
					.WithOne(x => x.ParentEntity)
					.IsRequired();

				modelBuilder.Entity<ChildEntity>()
					.ToTable("child");
			});
		}
	}

	public class DesignTimeContextFactory : IDesignTimeDbContextFactory<MyDbContext>
	{
		public MyDbContext CreateDbContext(string[] args)
		{
			return new MyDbContext(Program.ConnectionString);
		}
	}
}