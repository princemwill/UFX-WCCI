namespace UFX_WCCI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcodeforpostpics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postings", "PhotoName", c => c.String());
            AddColumn("dbo.Postings", "PhotoType", c => c.String());
            AddColumn("dbo.Postings", "PhotoBytes", c => c.Binary());
            AddColumn("dbo.Postings", "FileTypePost", c => c.Int(nullable: false));
            DropColumn("dbo.Postings", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Postings", "Photo", c => c.String());
            DropColumn("dbo.Postings", "FileTypePost");
            DropColumn("dbo.Postings", "PhotoBytes");
            DropColumn("dbo.Postings", "PhotoType");
            DropColumn("dbo.Postings", "PhotoName");
        }
    }
}
