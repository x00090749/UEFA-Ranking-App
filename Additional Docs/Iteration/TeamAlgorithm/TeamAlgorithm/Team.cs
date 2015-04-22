using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TeamAlgorithm
{
    public enum TeamNames //TransactionType
    {
        Lincoln_Red_Imps,
        Fc_Santa_Coloma,
        La_Fiorita,
        Hb_Torshavn,
        Banants_Yerevan,
        Levadia_Tallinn
    }

    public class Team
    {
        public String Id { get; set; }
        public TeamNames TeamName { get; set; }
        public double CoEfficient { get; set; }

        public String NameOfTeam { get; set; }

        //1 constructor
        public Team(String id, /*TeamNames teamName, */String nameOfTeam,double coEfficient)
        {
            this.Id = id;
            //this.TeamName = teamName;
            this.NameOfTeam = nameOfTeam;
            this.CoEfficient = coEfficient;
        }

        public override string ToString()
        {
            return "Id: " + Id + " Name: " + NameOfTeam + " CoEfficient: " + CoEfficient;
        }
    }

    //Teams class

    public class TeamClass : IEnumerable
    {
        public String Crn { get; set; }

        private List<Team> teams; //Strongly Typed

        //1 constructor
        public TeamClass(String crn)
        {
            this.Crn = crn;
            teams = new List<Team>();
        }

        //Add a team to the class, if not already in the class
        public void AddTeam(Team team)
        {
            if (teams == null)
            {
                teams.Add(team);
            }

            else
            {
                if((teams.Count(s => s.Id == team.Id)) == 1)
                {
                    throw new ArgumentException("Error team " + team.NameOfTeam + " is already in the class");
                }
                else
                {
                    teams.Add(team);
                }   
            }
        }

        //indexer based on an int
        public Team this[int i]
        {
            get
            {
                //validate index values
                if ((i >= 0) & (i < teams.Count))
                {
                    return teams[i];
                }
                else
                {
                    {
                        throw new ArgumentException("Error: student index out of range");
                    }
                }
            }
        }

        //indexer based in a string
        public Team this[String id]
        {
            get
            {
                
                //find matching team and return

                Team team = null;
                int count = teams.Count(s => s.Id == id);
                if (count == 1)
                {
                    team = teams.Where(s => s.Id == id).First();
                    return team;
                }
                else
                {
                    throw new ArgumentException("No matching team found");
                }
            }
        }

        //Iterate of team collection - foreach now possible on a teamclass
        public IEnumerator GetEnumerator()
        {
            foreach (Team team in teams)
            {
                yield return team;
            }
        }
    }

    class Test
    {
        public static void Main()
        {
            try
            {
                //create 2 teams
                Team t1 = new Team("1", "Lincoln Red Imps", 0.000);
                Team t2 = new Team("2", "FC Santa Coloma", 2.166);
                Team t3 = new Team("3", "La Fiorita", 0.699);
                Team t4 = new Team("4", "HB Torshavn", 3.175);
                Team t5 = new Team("5", "Bananta Yerevan", 1.325);
                Team t6 = new Team("6", "Levadia Tallinn", 4.575);

                //double[] values = {0.000, 2.166, 0.699, 3.175, 1.325, 4.575};

                //List<Team> sortedList = objListTeam.OrderBy(o => o.Order)

                

                //Add the class
                TeamClass roundOne = new TeamClass("Round One");

                //add the teams
                roundOne.AddTeam(t1);
                roundOne.AddTeam(t2);
                roundOne.AddTeam(t3);
                roundOne.AddTeam(t4);
                roundOne.AddTeam(t5);
                roundOne.AddTeam(t6);

                

                Console.WriteLine("Qualifying Round:  " + roundOne.Crn + "\n");
                foreach (Team team in roundOne) //use iterator
                {
                    Console.WriteLine("Name: " + team.NameOfTeam + " CoEfficient: " + team.CoEfficient);
                    
                }

                // try to find a player
                Team t = roundOne["1"]; //use overloaded indexer
                Console.WriteLine("\nFound " + t);

                t = roundOne[1];
                Console.WriteLine("Found " + t);
                

                Console.WriteLine("Calculating Seedings...");
                double temp = 0;

                double[] vals = {t1.CoEfficient, t2.CoEfficient, t3.CoEfficient, t4.CoEfficient, t5.CoEfficient, t6.CoEfficient};

                Array.Sort(vals);

                foreach (double value in vals)
                {
                    Console.Write(value);
                    Console.Write(' ');
                    
                }
                Console.WriteLine();

               // TeamList = TeamList.Orderby

                Console.WriteLine("\nSeeded: \n" + t1 + "\n" + t2 + "\n" + t3 + "\nUnseeded: \n" + t4 + "\n" + t5 + "\n" + t6);

                Console.ReadLine();
            }
            catch (ArgumentException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
        }
    }
}
