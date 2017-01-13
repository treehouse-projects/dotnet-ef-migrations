namespace ComicBookGalleryModel.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComicBookGalleryModel.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ComicBookGalleryModel.Data.Context context)
        {
            const int roleIdScript = 1;
            const int roleIdPencils = 2;

            context.Roles.AddOrUpdate(
                r => r.Id,
                new Role() { Id = roleIdScript, Name = "Script" },
                new Role() { Id = roleIdPencils, Name = "Pencils" }
            );

            const int artistIdStanLee = 1;
            const int artistIdSteveDitko = 2;

            context.Artists.AddOrUpdate(
                a => a.Id,
                new Artist() { Id = artistIdStanLee, Name = "Stan Lee" },
                new Artist() { Id = artistIdSteveDitko, Name = "Steve Ditko" }
            );

            const int seriesIdSpiderMan = 1;

            context.Series.AddOrUpdate(
                s => s.Id,
                new Series()
                {
                    Id = seriesIdSpiderMan,
                    Title = "The Amazing Spider-Man",
                    Description = "The Amazing Spider-Man (abbreviated as ASM) is an American comic book series published by Marvel Comics, featuring the adventures of the fictional superhero Spider-Man. Being the mainstream continuity of the franchise, it began publication in 1963 as a monthly periodical and was published continuously, with a brief interruption in 1995, until its relaunch with a new numbering order in 1999. In 2003 the series reverted to the numbering order of the first volume. The title has occasionally been published biweekly, and was published three times a month from 2008 to 2010. A film named after the comic was released July 3, 2012."
                }
            );

            var comicBook1 = new ComicBook()
            {
                Id = 1,
                SeriesId = seriesIdSpiderMan,
                IssueNumber = 1,
                Description = "As Peter Parker and Aunt May struggle to pay the bills after Uncle Bens death, Spider-Man must try to save a doomed John Jameson from his out of control spacecraft. / Spideys still trying to make ends meet so he decides to try and join the Fantastic Four. When that becomes public knowledge the Chameleon decides to frame Spider-Man and steals missile defense plans disguised as Spidey.",
                PublishedOn = new DateTime(1963, 3, 1),
                AverageRating = 7.1m
            };
            comicBook1.AddArtist(artistIdStanLee, roleIdScript);
            comicBook1.AddArtist(artistIdSteveDitko, roleIdPencils);

            context.ComicBooks.AddOrUpdate(
                cb => cb.Id,
                comicBook1
            );

            var comicBook2 = new ComicBook()
            {
                Id = 2,
                SeriesId = seriesIdSpiderMan,
                IssueNumber = 2,
                Description = "The Vulture becomes the city's most feared thief. Spider-Man must find a way to figure out his secrets and defeat this winged menace. / Spider-Man is up against The Tinkerer and a race of aliens who are trying to invade Earth.",
                PublishedOn = new DateTime(1963, 5, 1),
                AverageRating = 6.8m
            };
            comicBook2.AddArtist(artistIdStanLee, roleIdScript);
            comicBook2.AddArtist(artistIdSteveDitko, roleIdPencils);

            context.ComicBooks.AddOrUpdate(
                cb => cb.Id,
                comicBook2
            );

            var comicBook3 = new ComicBook()
            {
                Id = 3,
                SeriesId = seriesIdSpiderMan,
                IssueNumber = 3,
                Description = "Spider-Man battles Doctor Octopus and is defeated, he considers himself a failure until the Human Torch gives a speech to his class which inspires him to go in prepared and win the day, leaving Doctor Octopus under arrest. Spider-Man visits the Torch with words of thanks.",
                PublishedOn = new DateTime(1963, 7, 1),
                AverageRating = 6.9m
            };
            comicBook3.AddArtist(artistIdStanLee, roleIdScript);
            comicBook3.AddArtist(artistIdSteveDitko, roleIdPencils);

            context.ComicBooks.AddOrUpdate(
                cb => cb.Id,
                comicBook3
            );
        }
    }
}
