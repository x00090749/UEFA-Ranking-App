using System.IO;
using System.Reflection;
using System.Text;
using CsvHelper;

namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UefaServiceV9.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<UefaServiceV9.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(UefaServiceV9.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(UefaServiceV9.Models.ApplicationDbContext context)
        {

            AddUserAndRole(context);

             context.Contacts.AddOrUpdate(p => p.Name,
       new Contact
       {
           Name = "Debra Garcia",
           Address = "1234 Main St",
           City = "Redmond",
           State = "WA",
           Zip = "10999",
           Email = "debra@example.com",
       },
        new Contact
        {
            Name = "Thorsten Weinrich",
            Address = "5678 1st Ave W",
            City = "Redmond",
            State = "WA",
            Zip = "10999",
            Email = "thorsten@example.com",
        },
        new Contact
        {
            Name = "Yuhong Li",
            Address = "9012 State st",
            City = "Redmond",
            State = "WA",
            Zip = "10999",
            Email = "yuhong@example.com",
        },
        new Contact
        {
            Name = "Jon Orton",
            Address = "3456 Maple St",
            City = "Redmond",
            State = "WA",
            Zip = "10999",
            Email = "jon@example.com",
        },
        new Contact
        {
            Name = "Diliana Alexieva-Bosseva",
            Address = "7890 2nd Ave E",
            City = "Redmond",
            State = "WA",
            Zip = "10999",
            Email = "diliana@example.com",
        }
        );

             Assembly assembly = Assembly.GetExecutingAssembly();
             const string resourceName = "UefaServiceV9.App_Data.TeamRanking.csv";
             using (Stream stream = assembly.GetManifestResourceStream(resourceName))
             {
                 if (stream != null)
                     using (var reader = new StreamReader(stream, Encoding.UTF8))
                     {
                         var csvReader = new CsvReader(reader);
                         csvReader.Configuration.WillThrowOnMissingField = false;
                         var records = csvReader.GetRecords<TeamRanking>().ToArray();

                         foreach (TeamRanking record in records)
                         {
                             context.TeamRankings.AddOrUpdate(record);
                         }

                     }
                 context.SaveChanges();
             }

             Assembly roundOneAssembly = Assembly.GetExecutingAssembly();
             const string roundOneResourceName = "UefaServiceV9.App_Data.RoundOne.csv";
             using (var stream = roundOneAssembly.GetManifestResourceStream(roundOneResourceName))
             {
                 if (stream != null)
                     using (var reader = new StreamReader(stream, Encoding.UTF8))
                     {
                         var csvReader = new CsvReader(reader);
                         csvReader.Configuration.WillThrowOnMissingField = false;
                         var records = csvReader.GetRecords<RoundOne>().ToArray();

                         foreach (RoundOne record in records)
                         {
                             context.RoundOnes.AddOrUpdate(record);
                         }

                     }
                 context.SaveChanges();
             }

             Assembly roundTwoAssembly = Assembly.GetExecutingAssembly();
             const string roundTwoResourceName = "UefaServiceV9.App_Data.RoundTwo.csv";
             using (Stream stream = roundTwoAssembly.GetManifestResourceStream(roundTwoResourceName))
             {
                 if (stream != null)
                     using (var reader = new StreamReader(stream, Encoding.UTF8))
                     {
                         var csvReader = new CsvReader(reader);
                         csvReader.Configuration.WillThrowOnMissingField = false;
                         var records = csvReader.GetRecords<RoundTwo>().ToArray();

                         foreach (RoundTwo record in records)
                         {
                             context.RoundTwoes.AddOrUpdate(record);
                         }

                     }
                 context.SaveChanges();
             }


             //Round 3 Champions Route

             Assembly roundThreeChampionsRouteAssembly = Assembly.GetExecutingAssembly();
             const string roundThreeChampionsRouteResourceName = "UefaServiceV9.App_Data.RoundThreeChampionsRoute.csv";
             using (Stream stream = roundThreeChampionsRouteAssembly.GetManifestResourceStream(roundThreeChampionsRouteResourceName))
             {
                 if (stream != null)
                     using (var reader = new StreamReader(stream, Encoding.UTF8)) //StreamReader was Var
                     {
                         var csvReader = new CsvReader(reader); //was streamreader
                         csvReader.Configuration.WillThrowOnMissingField = false;
                         var records = csvReader.GetRecords<RoundThreeChampionsRoute>().ToArray();

                         foreach (RoundThreeChampionsRoute record in records)
                         {
                             context.RoundThreeChampionsRoutes.AddOrUpdate(record);
                         }

                     }
                 context.SaveChanges();
             }



             //Round 3 League Route

             Assembly roundThreeLeagueRouteAssembly = Assembly.GetExecutingAssembly();
             const string roundThreeLeagueRouteResourceName = "UefaServiceV9.App_Data.RoundThreeLeagueRoute.csv";
             using (Stream stream = roundThreeLeagueRouteAssembly.GetManifestResourceStream(roundThreeLeagueRouteResourceName))
             {
                 if (stream != null)
                     using (var reader = new StreamReader(stream, Encoding.UTF8)) //StreamReader was Var
                     {
                         var csvReader = new CsvReader(reader); //was streamreader
                         csvReader.Configuration.WillThrowOnMissingField = false;
                         var records = csvReader.GetRecords<RoundThreeLeagueRoute>().ToArray();

                         foreach (RoundThreeLeagueRoute record in records)
                         {
                             context.RoundThreeLeagueRoutes.AddOrUpdate(record);
                         }

                     }
                 context.SaveChanges();
             }


                        //Round 4 League Route

            Assembly roundFourLeagueRouteAssembly = Assembly.GetExecutingAssembly();
            const string roundFourLeagueRouteResourceName = "UefaServiceV9.App_Data.RoundFourLeagueRoute.csv";
            using (
                Stream stream = roundFourLeagueRouteAssembly.GetManifestResourceStream(roundFourLeagueRouteResourceName)
                )
            {
                if (stream != null)
                    using (var reader = new StreamReader(stream, Encoding.UTF8)) //StreamReader was Var
                    {
                        var csvReader = new CsvReader(reader); //was streamreader
                        csvReader.Configuration.WillThrowOnMissingField = false;
                        var records = csvReader.GetRecords<RoundFourLeagueRoute>().ToArray();

                        foreach (RoundFourLeagueRoute record in records)
                        {
                            context.RoundFourLeagueRoutes.AddOrUpdate(record);
                        }

                    }
                context.SaveChanges();
            }

            //Group Stage

            Assembly groupStageAssembly = Assembly.GetExecutingAssembly();
            const string groupStageResourceName = "UefaServiceV9.App_Data.GroupStage.csv";
            using (
                Stream stream = groupStageAssembly.GetManifestResourceStream(groupStageResourceName)
                )
            {
                if (stream != null)
                    using (var reader = new StreamReader(stream, Encoding.UTF8)) //StreamReader was Var
                    {
                        var csvReader = new CsvReader(reader); //was streamreader
                        csvReader.Configuration.WillThrowOnMissingField = false;
                        var records = csvReader.GetRecords<GroupStage>().ToArray();

                        foreach (GroupStage record in records)
                        {
                            context.GroupStages.AddOrUpdate(record);
                        }

                    }
                context.SaveChanges();
            }


            //
        }
    }
}
