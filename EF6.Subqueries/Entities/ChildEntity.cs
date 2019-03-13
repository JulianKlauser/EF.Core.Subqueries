using System.ComponentModel.DataAnnotations.Schema;

namespace EF6.Subqueries.Entities
{
	[Table("child")]
	public class ChildEntity
	{
		public int Id { get; set; }
		public string Value { get; set; }

		public int ParentEntityId { get; set; }
		public ParentEntity ParentEntity { get; set; }
	}
}