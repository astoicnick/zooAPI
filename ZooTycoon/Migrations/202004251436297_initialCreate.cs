namespace ZooTycoon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ZookeeperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Zookeepers", t => t.ZookeeperId, cascadeDelete: true)
                .Index(t => t.ZookeeperId);
            
            CreateTable(
                "dbo.Zookeepers",
                c => new
                    {
                        ZookeeperId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AnimalsCaringFor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZookeeperId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "ZookeeperId", "dbo.Zookeepers");
            DropIndex("dbo.Animals", new[] { "ZookeeperId" });
            DropTable("dbo.Zookeepers");
            DropTable("dbo.Animals");
        }
    }
}
