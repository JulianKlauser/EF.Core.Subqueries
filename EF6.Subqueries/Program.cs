using System;
using System.Collections.Generic;
using System.Linq;
using EF6.Subqueries.Entities;

namespace EF6.Subqueries
{
	class Program
	{
		public const string ConnectionString = "User Id=root;password=yourPasswordGoesHere;server=localhost;database=ef_6_test;port=6614;Allow User Variables=True;charset=utf8;";

		static void Main(string[] args)
		{
			using (var context = new MyDbContext(ConnectionString))
			{
				// This works as expected
				var result = context.Set<ParentEntity>()
					.Where(parent => parent.ChildEntities.Any(child => child.Value == "Dummy"))
					.ToList();

				Console.WriteLine(result.Count);

				// This throws an exception in EF Core, works in EF6
				var result2 = context.Set<ParentEntity>()
					.Where(parent => parent.ChildEntities.AsQueryable().Any(child => child.Value == "Dummy"))
					.ToList();

				Console.WriteLine(result2.Count);
			}
		}
	}
}
