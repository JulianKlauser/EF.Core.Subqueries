namespace EF.Core.Subqueries
{
	public class ChildEntity
	{
		public int Id { get; set; }
		public string Value { get; set; }

		public int ParentEntityId { get; set; }
		public ParentEntity ParentEntity { get; set; }
	}
}