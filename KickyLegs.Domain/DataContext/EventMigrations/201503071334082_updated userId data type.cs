namespace KickyLegs.Domain.DataContext.EventMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateduserIddatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "UserId", c => c.Guid(nullable: false));
        }
    }
}
