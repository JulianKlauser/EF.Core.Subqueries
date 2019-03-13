namespace EF6.Subqueries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "child",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(unicode: false),
                        ParentEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("parent", t => t.ParentEntityId, cascadeDelete: true)
                .Index(t => t.ParentEntityId);
            
            CreateTable(
                "parent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("child", "ParentEntityId", "parent");
            DropIndex("child", new[] { "ParentEntityId" });
            DropTable("parent");
            DropTable("child");
        }
    }
}
