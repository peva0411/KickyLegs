namespace KickyLegs.Domain.DataContext.EventMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedcaffeinetime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "LastCaffeine");
            AddColumn("dbo.Events", "LastCaffeine", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "LastCaffeine");
            AddColumn("dbo.Events", "LastCaffeine", c => c.DateTime());
        }
    }
}
