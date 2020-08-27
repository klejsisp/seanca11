namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shtopershkrimtekprodukti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "pershkrim", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "pershkrim");
        }
    }
}
