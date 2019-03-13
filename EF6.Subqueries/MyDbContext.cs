using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EF6.Subqueries.Entities;
using MySql.Data.Entity;

namespace EF6.Subqueries
{
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class MyDbContext : DbContext
	{
		public MyDbContext(string connectionString) : base(connectionString)
		{
		}

		public DbSet<ChildEntity> Children { get; set; }
		public DbSet<ParentEntity> Parents { get; set; }
	}

	public class DesignTimeContextFactory : IDbContextFactory<MyDbContext>
	{
		public MyDbContext Create()
		{
			return new MyDbContext(Program.ConnectionString);
		}
	}
}