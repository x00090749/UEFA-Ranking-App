using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UEFA_Ranking_V1.Models;

namespace UEFA_Ranking_V1.Models
{

    public enum TeamDescriptions
    {
        Country, Team
    }


    public class TeamOld
    {
        public int Id { get; set; }
        public TeamDescriptions CountrySelect { get; set; }
        public TeamDescriptions TeamSelect { get; set; }
       

        public List<Models.CountryRanking> Testing = new List<CountryRanking>();
        Models.CountryRanking _cr1 = new CountryRanking("Spain", 88.999);
        Models.CountryRanking _cr2 = new CountryRanking("Germany", 80.123);

       


       /* public double Ranking
        {
            get
            {
              /*  string s1 = "The quick brown fox jumps over the lazy dog";
                string s2 = "fox";
                bool b;
                b = s1.Contains(s2);*/

                /*double ranking = 0.00;
        
                if (CountrySelect == TeamDescriptions.Country)
                {

                    if (TeamSelect == TeamDescriptions.Team)
                    {
                        foreach (Models.CountryRanking testTeam in testing)
                        {
                            Console.WriteLine(testing);

                            if (testing.Any(str => str.TeamName.Contains("Spain"))) //teamname?
                            {
                                ranking = 88.999;
                            }
                        }
                    }

                   /* for(int i = 0; i < testing.Count; i++)
                    {
                        var matchingvalues = testing
    .Where(stringToCheck => stringToCheck.Contains(TeamDescriptions.Team));
                        //if(testing[i] )
                    }*/
                //}


               // return ranking;
           // }
        //}



        //[Display(Name = "Team: ")]
        public static String[] TeamNames = { "Lincoln Red Imps", "Levadia Tallinn", "La Fiorita"
        , "HB Torshavn", "Banants", "FC Santa Coloma"};
         

        //[Display(Name = "Country: ")]
        public static String[] Country = { "Gibraltar", "Estonia", "San Marino", 
                    "Faroe Islands", "Armenia", "Andorra"};



        // Team selection e.g. Levadia Tallinn, Lincoln Red Imps
        [Required(ErrorMessage = "Required field!")]
        [DisplayName("Teams")]
        public String Teams { get; set; }

       /* public static String[] SortRanking
        {
            get
            {
                string roundToEnter;
                List<Models.CountryRanking> testing = new List<CountryRanking>();
                Models.CountryRanking cr1 = new CountryRanking("Spain", 88.999);
                Models.CountryRanking cr2 = new CountryRanking();



                testing.Add(cr1);
                
                String[] rounds =
                {
                    "1st Round", "2nd Round",
                    "Third Round Champions", "Group Stage",
                };

                for (int i = 0; i < Team.TeamNames.Length; i++)
                {
                    if (TeamNames[i] <= TeamNames.Length + 1)
                    {
                        
                    }
                }

                
            }
        }

        //Calculate the Round to which the team enters.

        public String CountryRanking
        {
            get
            {
                String roundToEnter = null;

                for (int i = 0; i <= Team.Country.Length; i++)
                {
                    if (Team.Country[i] == Team.Country[i])
                    {
                        roundToEnter = "First Round";
                        break;
                    }
                }
                return roundToEnter;
            }
        }*/


        //[Display(Name = "Club Coefficient: ")]
        ////public double coefficient { get; set; }
        //[Display(Name = "Champions League Round: ")]
       // public string RoundToEnter { get; set; }

        /*private int CountryRank;
        public int countryRank
        {
            get { return CountryRank; }

            set { CountryRank = value; }

        }


        /*public double countryName
        
        {
            
        }*/
        
    /*    public int CheckRound(String rank)
        {
            
            if (Country.countryRank <= 54 && Country.countryRank >= 47)
            {
                rank = "First Round";
                return rank;
            }



        }
        */
    }

  /*  public class TeamDBContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
    }*/
}