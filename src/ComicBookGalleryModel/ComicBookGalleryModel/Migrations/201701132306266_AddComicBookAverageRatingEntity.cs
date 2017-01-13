namespace ComicBookGalleryModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComicBookAverageRatingEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComicBookAverageRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComicBookId = c.Int(nullable: false),
                        AverageRating = c.Decimal(nullable: false, precision: 5, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComicBook", t => t.ComicBookId, cascadeDelete: true)
                .Index(t => t.ComicBookId);

            // Populate the ComicBookAverageRating table.
            Sql(@"
                insert into ComicBookAverageRating
                select Id, AverageRating, getdate() from ComicBook 
                where AverageRating is not null
            ");
            
            DropColumn("dbo.ComicBook", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComicBook", "AverageRating", c => c.Decimal(precision: 5, scale: 2));

            // Populate the ComicBook.AverageRating column.
            Sql(@"
                update cb
                set cb.AverageRating = cbar.AverageRating
                from ComicBook cb
                cross apply (
                    select top 1 AverageRating, Date
                    from ComicBookAverageRating 
                    where ComicBookId = cb.Id
                    order by Date desc
                ) as cbar
            ");

            DropForeignKey("dbo.ComicBookAverageRating", "ComicBookId", "dbo.ComicBook");
            DropIndex("dbo.ComicBookAverageRating", new[] { "ComicBookId" });
            DropTable("dbo.ComicBookAverageRating");
        }
    }
}
