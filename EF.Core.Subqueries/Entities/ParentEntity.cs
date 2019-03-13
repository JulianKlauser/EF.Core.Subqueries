using System.Collections.Generic;

namespace EF.Core.Subqueries.Entities
{
	public class ParentEntity
	{
		public int Id { get; set; }
		public string Value { get; set; }

		public List<ChildEntity> ChildEntities { get; set; }
	}
}