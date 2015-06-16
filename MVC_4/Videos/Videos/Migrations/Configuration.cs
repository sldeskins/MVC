namespace Videos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Videos.Models.VideoDb>
    {
        public Configuration ()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed ( Videos.Models.VideoDb context )
        {
            context.Videos.AddOrUpdate(v => v.Title,
                new Videos.Models.Video()
                {
                    Title = "MVC4",
                    Length = 120
                },
                new Videos.Models.Video()
                {
                    Title = "LINQ",
                    Length = 87
                });

            context.SaveChanges();
        }
    }
}