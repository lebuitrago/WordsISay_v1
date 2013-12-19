namespace WordsISay_v1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WordsISay_v1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WordsISay_v1.Models.WordsISay_v1_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WordsISay_v1.Models.WordsISay_v1_Context";
        }

        protected override void Seed(WordsISay_v1.Models.WordsISay_v1_Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Stories.AddOrUpdate(i => i.Name,
            new Story
            {
                Name = "Walk in the Park",
                Plot = "Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                DateCreated = DateTime.Parse("2013-12-01"),
                ImageURL = "http://i.imgur.com/jfGqBAG.jpg?1",
            },

            new Story
            {
                Name = "Phrase of the Week",
                Plot = "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain.",
                DateCreated = DateTime.Parse("2013-12-05"),
                ImageURL = "http://i.imgur.com/qrp6Kf8.jpg",
            },

            new Story
            {
                Name = "Once upon a Time",
                Plot = "To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?",
                DateCreated = DateTime.Parse("2013-12-07"),
                ImageURL = "http://i.imgur.com/Ug4UaDe.jpg",
            },

            new Story
            {
                Name = "And so it goes on and on",
                Plot = "The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                DateCreated = DateTime.Parse("2013-12-02"),
                ImageURL = "http://i.imgur.com/jfGqBAG.jpg?1",
            },

            new Story
            {
                Name = "Transformers are in Town",
                Plot = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                DateCreated = DateTime.Parse("2013-12-01"),
                ImageURL = "http://i.imgur.com/EHljyk6.jpg",
            }
            );
        }
    }
}
