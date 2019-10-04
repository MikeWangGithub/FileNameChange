namespace FCNDBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20191004 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Files", "FileName", c => c.String(nullable: false, maxLength: 240));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Files", "FileName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
