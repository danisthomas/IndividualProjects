using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Repo
{
    public class Developer_Repository
    {
        private List<Developer> _listOfDevelopers = new List<Developer>();

        public Developer DevId { get; set; }

        //Create

        public void AddDevlopersToList(Developer developer)
        {
            _listOfDevelopers.Add(developer);
        }

        //Read
        public List<Developer> GetDevelopers()
        {
            return _listOfDevelopers;
        }

        //Update

        public bool UpdateListOfDevelopers(int originalDeveloperId, Developer newContent)
        {
            //Find Content

            Developer oldContent = GetDeveloperByDevId(originalDeveloperId);

            if (oldContent != null)
            {
                oldContent.FullName = newContent.FullName;
                oldContent.DevId = newContent.DevId;
                oldContent.HasPluralsightAccess = newContent.HasPluralsightAccess;
                oldContent.DevTeamId = newContent.DevTeamId;

                return true;
            }
            else
            {
                return false;

            }

            //Delete
        }
        public bool RemoveDeveloperFromList (int devId)
        {
                Developer developer = GetDeveloperByDevId(devId);
                if (developer.DevId != devId)
                {
                    return false;
                }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);
            if(initialCount > _listOfDevelopers.Count)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        
            


        //Helper

        public Developer GetDeveloperByDeveloperName(String fullName)
        {
            
            foreach (Developer dev in _listOfDevelopers)
            {

                if (dev.FullName.ToLower() == fullName.ToLower())
                {
                    return dev;
                        
                }

            }

            return null;
        

        }

        public Developer GetDeveloperByDevId(int devId)
        {   
            foreach (Developer dev in _listOfDevelopers)
            {
                if (dev.DevId == devId)
                {
                    return dev;
                }
            }
            return null;

        }
        public List<Developer> GetListOfDevelopersInTeamByTeamId(int devTeamId)
        {
            List<Developer> developers = new List<Developer>();

            foreach(Developer dev in _listOfDevelopers)
            {
                if (dev.DevTeamId == devTeamId)
                {
                     developers.Add(dev);
                }
            }

            return developers;
        }
    }

}
