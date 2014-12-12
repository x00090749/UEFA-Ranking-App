using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;

namespace UEFA_Ranking_V1.Models
{


    public class CountryRanking
    {

        private String teamName;
        private double ranking;

        public CountryRanking(String teamName, double ranking)
        {
            TeamName = teamName;
            Ranking = ranking;
        }

        public String TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }

        public double Ranking
        {
            get { return ranking; }
            set { ranking = value; }
        }

        /*string csv_file_path = @"C:\Users\Daniel\Desktop\Project\CountryRankings.csv";
        DataTable csvData = GetDataTabletFromCSVFile(csv_file_path);*/



    }
}