namespace KickyLegs.Domain.DataContext.EventMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        LastCaffeine = c.DateTime(),
                        LastFood = c.String(maxLength: 512),
                        Duration = c.Int(nullable: false),
                        Notes = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
