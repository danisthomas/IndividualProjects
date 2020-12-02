using Developer_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class DevTeam_Repository
    {

        private List<DevTeam> _listOfDevTeams = new List<DevTeam>();
        //Create
        public void AddTeamToList(DevTeam team)
        {
            _listOfDevTeams.Add(team);
        }



        //Read
        public List<DevTeam> GetAllTeams()
        {
            return _listOfDevTeams;
        }

        


        //Update
        public bool UpdateCurrentListOfTeams(int originalTeamId, DevTeam newContent)
        {
            //Find content
            DevTeam oldcontent = GetTeamByDevTeamId(originalTeamId);
            

          
            //Update content

            if(oldcontent != null)
            {
                oldcontent.TeamName = newContent.TeamName;
                oldcontent.TeamId = newContent.TeamId;
                oldcontent.TeamMembers = newContent.TeamMembers;

                return true;

            }
            else
            {
                return false;
            }
        }


        //Delete
         public bool RemoveContentFromList(int teamId)
         {
            DevTeam team = GetTeamByDevTeamId(teamId);

            if (team.TeamId != teamId)
            {

                {
                    return false;

                }

            }
                int initialCount = _listOfDevTeams.Count;
                _listOfDevTeams.Remove(team);

                if(initialCount > _listOfDevTeams.Count)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            
         }

        //Helper

        public DevTeam GetTeamByTeamName(String teamName)
        {
            foreach (DevTeam team in _listOfDevTeams)
            {

                if (team.TeamName.ToLower() == teamName.ToLower())
                {
                    return team;
                }

            }

            return null;
            
        }


        public DevTeam GetTeamByDevTeamId(int devTeamId)
        {
            foreach (DevTeam team in _listOfDevTeams)
            {
                if (team.TeamId == devTeamId)
                {
                    return  team;
                }
            }
            return null;

        }
      
       
    }
}
