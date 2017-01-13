namespace ComicBookGalleryModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComicBookArtist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComicBookId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.ComicBook", t => t.ComicBookId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.ComicBookId)
                .Index(t => t.ArtistId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ComicBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeriesId = c.Int(nullable: false),
                        IssueNumber = c.Int(nullable: false),
                        Description = c.String(),
                        PublishedOn = c.DateTime(nullable: false),
                        AverageRating = c.Decimal(precision: 5, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .Index(t => t.SeriesId);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComicBookArtist", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ComicBook", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.ComicBookArtist", "ComicBookId", "dbo.ComicBook");
            DropForeignKey("dbo.ComicBookArtist", "ArtistId", "dbo.Artist");
            DropIndex("dbo.ComicBook", new[] { "SeriesId" });
            DropIndex("dbo.ComicBookArtist", new[] { "RoleId" });
            DropIndex("dbo.ComicBookArtist", new[] { "ArtistId" });
            DropIndex("dbo.ComicBookArtist", new[] { "ComicBookId" });
            DropTable("dbo.Role");
            DropTable("dbo.Series");
            DropTable("dbo.ComicBook");
            DropTable("dbo.ComicBookArtist");
            DropTable("dbo.Artist");
        }
    }
}
