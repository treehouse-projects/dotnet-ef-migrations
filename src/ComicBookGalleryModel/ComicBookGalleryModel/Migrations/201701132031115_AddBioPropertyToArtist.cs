namespace ComicBookGalleryModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBioPropertyToArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artist", "Bio", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artist", "Bio");
        }
    }
}
