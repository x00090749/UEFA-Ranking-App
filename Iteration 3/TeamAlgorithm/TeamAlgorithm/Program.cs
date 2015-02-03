using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public enum TeamName //TransactionType
    {
        Lincoln_Red_Imps,
        FC_Santa_Coloma,
        La_Fiorita,
        HB_Torshavn,
        Banants_Yerevan,
        Levadia_Tallinn
    }


    public class Team
    {
        private TeamName name; //6 first round teams
        private double coefficient; //Their coefficients

        //constructor
        public Team(TeamName name, double coefficient)
        {
            this.name = name;
            this.coefficient = coefficient;
        }

        //return readable string

        public override string ToString()
        {
 	        return "Team: " + name + " coefficient: " + coefficient;
        }
        
    }

   

       // return human readable String - for CurrentAccount including transaction history
       /*public override String ToString()
       {
           String output;

           output = "CurrentAcount:\t" + "number: " + name + " balance: " + coefficient;

    /*       output += "\nTransaction history:\n";
           for (int i = 0; i < nextTransactionNo; i++)
           {
               output += transactionHistory[i].ToString() + "\n";
           }*/

          // return output;
      // }
   }
}
