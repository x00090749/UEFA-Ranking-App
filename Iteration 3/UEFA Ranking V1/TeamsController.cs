using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Antlr.Runtime.Misc;

using UEFA_Ranking_V1.Models;

namespace UEFA_Ranking_V1.Controllers
{
    public class TeamsController : ApiController
    {
        private Team[] teams = new Team[]
        {
            new Team{ Id =  1, Teams = ""},
           // new Team{ Id = 2, Teams = "TestTeamTwo"},
        };

        public IEnumerable<Team> GetAllTeams()
        {
            return teams;
        }

        public IHttpActionResult GetTeam(int id)
        {
            var team = teams.FirstOrDefault((p) => p.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }



        // GET api/values
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

    }

    
}
