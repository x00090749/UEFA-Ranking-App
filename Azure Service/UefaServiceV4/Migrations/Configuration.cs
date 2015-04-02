using System.IO;
using System.Reflection;
using System.Text;
using CsvHelper;
using UefaServiceV4.Models;

namespace UefaServiceV4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UefaServiceV4.Models.UefaServiceV4Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UefaServiceV4.Models.UefaServiceV4Context context)
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


            context.Countries.AddOrUpdate(x => x.Id,
                                new Country() { Id = 8, CountryName = "Northern Ireland", CountryCode = "NIR", Position = 47 },
                new Country() { Id = 7, CountryName = "Wales", CountryCode = "WAL", Position = 48 },
                new Country() { Id = 6, CountryName = "Armenia", CountryCode = "ARM", Position = 49 },
                new Country() { Id = 5, CountryName = "Estonia", CountryCode = "EST", Position = 50 },
                new Country() { Id = 4, CountryName = "Faroe Islands", CountryCode = "FAR", Position = 51 },
                new Country() { Id = 3, CountryName = "San Marino", CountryCode = "SMA", Position = 52 },
                new Country() { Id = 2, CountryName = "Andorra", CountryCode = "AND", Position = 53 },
                new Country() { Id = 1, CountryName = "Gibraltar", CountryCode = "GRB", Position = 54 }
                );

            context.Teams.AddOrUpdate(x => x.Id,
                new Team() { Id = 1, TeamName = "Lincoln Red Imps", CountryId = 1 },
                new Team() { Id = 2, TeamName = "FC Santa Coloma", CountryId = 2 },
                new Team() { Id = 3, TeamName = "Tre Fiori", CountryId = 3 },
                new Team() { Id = 4, TeamName = "B36 Tórshavn", CountryId = 4 },
                new Team() { Id = 5, TeamName = "Levadia Tallinn", CountryId = 5 },
                new Team() { Id = 6, TeamName = "Ulisses Yeraven", CountryId = 6 },
                new Team() { Id = 7, TeamName = "The New Saints", CountryId = 7 },
                new Team() { Id = 8, TeamName = "Crusaders", CountryId = 8 }
                );



            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "UefaServiceV4.App_Data.TeamRanking.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    var records = csvReader.GetRecords<TeamRanking>().ToArray();

                    foreach (TeamRanking record in records)
                    {
                        context.TeamRankings.AddOrUpdate(record);
                    }

                }
                context.SaveChanges();
            }


        }
    }
}
