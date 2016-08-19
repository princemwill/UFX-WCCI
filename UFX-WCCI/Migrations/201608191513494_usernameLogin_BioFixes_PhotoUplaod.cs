namespace UFX_WCCI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameLogin_BioFixes_PhotoUplaod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PhotoName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhotoType", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhotoBytes", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "FileType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FileType");
            DropColumn("dbo.AspNetUsers", "PhotoBytes");
            DropColumn("dbo.AspNetUsers", "PhotoType");
            DropColumn("dbo.AspNetUsers", "PhotoName");
        }
    }
}
