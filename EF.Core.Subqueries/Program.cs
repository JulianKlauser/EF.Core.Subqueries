using System;
using System.Linq;

namespace EF.Core.Subqueries
{
	class Program
	{
		public const string ConnectionString = "User Id=root;password=yourPasswordGoesHere;server=localhost;database=ef_core_test;port=6614;Allow User Variables=True;charset=utf8;";

		static void Main(string[] args)
		{
			using (var context = new MyDbContext(ConnectionString))
			{
				// This works as expected
				var result = context.Set<ParentEntity>()
					.Where(parent => parent.ChildEntities.Any(child => child.Value == "Dummy"))
					.ToList();

				Console.WriteLine(result.Count);

				// This throws an exception
				var result2 = context.Set<ParentEntity>()
					.Where(parent => parent.ChildEntities.AsQueryable().Any(child => child.Value == "Dummy"))
					.ToList();

				Console.WriteLine(result2.Count);
			}
		}
	}
}
