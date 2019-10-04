namespace FCNDBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20191003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Check",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        CheckDirectory = c.String(maxLength: 300),
                        Total = c.Int(nullable: false),
                        Valid = c.Int(nullable: false),
                        Invalid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CheckID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 100),
                        FileFullName = c.String(nullable: false, maxLength: 300),
                        FilePath = c.String(nullable: false, maxLength: 300),
                        Extension = c.String(nullable: false, maxLength: 10),
                        IsValid = c.Boolean(nullable: false),
                        Size = c.Int(nullable: false),
                        Size_Abbreviation = c.String(maxLength: 30),
                        Memo = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Check", t => t.CheckID, cascadeDelete: true)
                .Index(t => t.CheckID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "CheckID", "dbo.Check");
            DropIndex("dbo.Files", new[] { "CheckID" });
            DropTable("dbo.Files");
            DropTable("dbo.Check");
        }
    }
}
