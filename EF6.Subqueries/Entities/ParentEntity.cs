using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6.Subqueries.Entities
{
	[Table("parent")]
	public class ParentEntity
	{
		public int Id { get; set; }
		public string Value { get; set; }

		public List<ChildEntity> ChildEntities { get; set; }
	}
}