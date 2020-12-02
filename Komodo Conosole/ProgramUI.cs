using Developer_Repo;
using DevTeams_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Conosole
{
    class ProgramUI
    {
        private DevTeam_Repository _contentDevTeamRepo = new DevTeam_Repository();
        private Developer_Repository _contentDevRepo = new Developer_Repository();


        public void Run()
        {
            SeedDevTeamList();
            SeedDeveloperList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1.  Add New Developer\n" +
                    "2.  Add New Dev Team\n" +
                    "3.  Add Developer to a Dev Team\n" +
                    "4.  View List of All Dev Teams\n" +
                    "5.  View List of Dev Teams by Name\n" +
                    "6.  View List of Dev Teams by TeamID\n" +
                    "7.  View List of All Developers\n" +
                    "8.  View List of Developers by Name\n" +
                    "9.  View List of Developers by DevId\n" +
                    "10. View List of Developers without Pluralsight Access by Name\n" +
                    "11. Update Existing Developer Content\n" +
                    "12. Update Existing Dev Team Content\n" +
                    "13. Delete Existing Developer Content\n" +
                    "14. Delete Existing Dev Team Content\n" +
                    "15. Exit");

                //Get user's input

                string input = Console.ReadLine();

                //Evaluate user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Add new Developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // Add new Dev Team
                        CreateNewDevTeam();
                        break;
                    case "3":
                        // Add developer to dev team
                        AddDeveloperToDevTeam();
                        break;
                    case "4":
                        //View List of All DevTeams
                        DisplayListOfAllDevTeams();
                        break;
                    case "5":
                        // View list of Dev Teams by Name
                        DisplayDevTeambyName();
                        break;
                    case "6":
                        // View list of Teams by ID
                        DisplayDevTeamsbyId();
                        break;
                    case "7":
                        //View List of All Developers
                        DisplayListOfAllDevelopers();
                        break;
                    case "8":
                        // View List of Developers by Name
                        DisplayDevelopersByName();
                        break;
                    case "9":
                        //View List of Developers by DevID
                        DisplayDevelopersByID();
                        break;
                    case "10":
                        //View lists of Developers Without PluralSight by Name
                        DevelopersWithoutPluralSightAccess();
                        break;

                    case "11":
                        //Update Existing Developer Content
                        UpdateExistingDeveloperContent();
                        break;
                    case "12":
                        //Update Existing DevTeam Content
                        UpdateExistingDevTeamContent();
                        break;
                    case "13":
                        //Delete Existing Developer Content
                        DeleteExistingDeveloperContent();
                        break;
                    case "14":
                        //Delete Existing DevTeam Content
                        DeleteExistingDevTeamContent();
                        break;
                    case "15":
                        //Exit   
                        Console.WriteLine("Have a Great Day!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //Create new Developer
        private void CreateNewDeveloper()
        {
            Developer newDeveloper = new Developer();
            //Full Name
            Console.WriteLine("Enter the name of the Developer:");
            newDeveloper.FullName = Console.ReadLine();

            //DevID
            Console.WriteLine("Enter the DevID for the Developer:");
            string devIdAsString = Console.ReadLine();
            newDeveloper.DevId = int.Parse(devIdAsString);

            //PluralSight Access
            Console.WriteLine("Does the Developer have Pluralsight Access?");
            string hasPluralAccessString = Console.ReadLine().ToLower();
            if (hasPluralAccessString == "y")
            {
                newDeveloper.HasPluralsightAccess = true;
            }
            else
            {
                newDeveloper.HasPluralsightAccess = false;
            }

            _contentDevRepo.AddDevlopersToList(newDeveloper);

        }

        //Create new Dev Team

        private void CreateNewDevTeam()
        {
            List<Developer> devTeamMembers = new List<Developer>();

            DevTeam newDevTeam = new DevTeam();
            //Name of DevTeam
            Console.WriteLine("Enter the name of the Dev Team.");
            newDevTeam.TeamName = Console.ReadLine();

            //DevTeam Id
            Console.WriteLine("Enter the DevTeam ID.");
            
            newDevTeam.TeamId = int.Parse(Console.ReadLine());
            newDevTeam.TeamMembers = devTeamMembers;
            _contentDevTeamRepo.AddTeamToList(newDevTeam);

        }

        //Add Developer to Dev Team

        private void AddDeveloperToDevTeam()
        {
            
            Console.WriteLine("Would you like to add a Developer to a Dev Team? Please enter yes or no.");
            string addDevToDevTeam = Console.ReadLine().ToLower();
            while (addDevToDevTeam == "y")
            {
                DisplayListOfAllDevelopers();
                Console.WriteLine("Enter the Developer ID of the Developer you wish to choose:");
               
                int developerAsInt = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the DevTeam ID you want to add the Developer to:");
               
                int addToDevTeamAsInt = int.Parse(Console.ReadLine());


                Developer developerToAdd = _contentDevRepo.GetDeveloperByDevId(developerAsInt);
                
                //DevTeam devTeamToAdd = new DevTeam();


                // List<Developer> teamOne = new List<Developer>();
                //List<Developer> teamTwo = new List<Developer>();
                //List<Developer> teamThree = new List<Developer>();
                if (developerAsInt == developerToAdd.DevId)
                {
                    developerToAdd.DevTeamId = addToDevTeamAsInt;
                }
                else
                {
                    Console.WriteLine("Cannot Add Developer to DevTeam.");
                }
                DisplayListOfAllDevelopers();
                Console.WriteLine("Would you like to add another Developer to a Dev Team? Please enter yes or no.");
                addDevToDevTeam = Console.ReadLine().ToLower();

            }
            Console.WriteLine("Press Any Key to Continue.");
            Console.ReadKey();
            
           
               // switch (addToDevTeamAsString)
               // {
               //     case "1":
              //          if (developerAsInt == developerToAdd.DevId && addToDevTeamAsInt == 1)
                        {
                //            developerToAdd.DevTeamId = addToDevTeamAsInt;
                        }
                  //      break;

                    //case "2":

                      //  if (developerAsInt == developerToAdd.DevId && addToDevTeamAsInt == 2)
                       // {
                         //   teamTwo.Add(developerToAdd);
                     //   }
                     //   break;
                    //case "3":
                      //  if (developerAsInt == developerToAdd.DevId && addToDevTeamAsInt == 3)
                       // {
                         //   teamThree.Add(developerToAdd);
                        //}
                        //break;
                   // default:
                     //   Console.WriteLine("Cannnot add Developer to List.");
                       //     break;

               // }
           // }
            //else
            //{
              //  Console.WriteLine("Thank You!");
            //}
            

           








        }

        //View list of All Dev Teams

        private void DisplayListOfAllDevTeams()
        {    
            
            List<DevTeam> listOfDevTeams = _contentDevTeamRepo.GetAllTeams();
            foreach (DevTeam team in listOfDevTeams)
            {
                Console.WriteLine($"Team Name : {team.TeamName}, Team ID: {team.TeamId}, Team Members: {team.TeamMembers.Count}");
            }

        }

        //View list of Dev Teams by Name
        private void DisplayDevTeambyName()
        {
            Console.WriteLine("Enter the Name of the Team you wish to find.");

            string teamNameInput =Console.ReadLine();

            DevTeam team = _contentDevTeamRepo.GetTeamByTeamName(teamNameInput);
                
           
                if (team != null)
                {
                    Console.WriteLine($"Team Name: {team.TeamName}, Team ID: {team.TeamId}, Team Members: {team.TeamMembers.Count}");
                  
                }

                else
                    Console.WriteLine("No Team was found by that name.");
            



        }

        //View list of Dev Teams by ID
        private void DisplayDevTeamsbyId()
        {
            Console.WriteLine("Enter the the number of the Dev Team you with to view (ie: 1, 2, 3....");
            string teamIdAsString = Console.ReadLine();
            int teamIdAsInt = int.Parse(teamIdAsString);

            DevTeam team = _contentDevTeamRepo.GetTeamByDevTeamId(teamIdAsInt);
            
                if (team != null)
                {
                    Console.WriteLine($"Team Name:{team.TeamName}, Team ID: {team.TeamId}, Team Members: {team.TeamMembers.Count}");
                }
                else
                {
                    Console.WriteLine("No Team was found with that Team ID.");
                }
            
        }

        //List of All Developers
        private void DisplayListOfAllDevelopers()
        {

            List<Developer> listOfDevevelopers = _contentDevRepo.GetDevelopers();
            foreach (Developer developer in listOfDevevelopers)
            {
                Console.WriteLine($"Developer Name : {developer.FullName}, Developer ID: {developer.DevId}, Dev Team ID: {developer.DevTeamId}, PluralSight Access: {developer.HasPluralsightAccess}");
            }

        }


        //View list of Developers by Name
        private void DisplayDevelopersByName()
        {
            Console.WriteLine("Enter the name of the Developer you wish to find.");
            string devNameInput = Console.ReadLine();

            Developer developer = _contentDevRepo.GetDeveloperByDeveloperName(devNameInput);

            if (developer != null)
            {
                Console.WriteLine($"Developer Name: {developer.FullName}, Developer ID: {developer.DevId}, DevTeam Number: {developer.DevTeamId}, PluralSightAccess: {developer.HasPluralsightAccess}");
            }
            else
            {
                Console.WriteLine("No Developer by that name found.");
            }

        }

        //view List of Developers by ID

        private void DisplayDevelopersByID()
        {
            Console.WriteLine("Enter Developer ID you wish to find.");
            string devIdAsString = Console.ReadLine();
            int devIdASInt = int.Parse(devIdAsString);

            Developer developer = _contentDevRepo.GetDeveloperByDevId(devIdASInt);


            if (developer != null)
            {
                Console.WriteLine($"Developer Name: {developer.FullName}, Developer ID: {developer.DevId}, DevTeam Number: {developer.DevTeamId}" );
            }
            else
            {
                Console.WriteLine("No Developer by that name found.");
            }

        }
        //View List of Developers without PluralSight Access
        private void DevelopersWithoutPluralSightAccess()
        {
            List<Developer> listOfDevevelopers = _contentDevRepo.GetDevelopers();
            foreach (Developer developer in listOfDevevelopers)
            {
                if (developer.HasPluralsightAccess == false)
                {
                    Console.WriteLine($"Developer Name : {developer.FullName}, Developer ID: {developer.DevId}, Dev Team ID: {developer.DevTeamId}, PluralSightAccess {developer.HasPluralsightAccess}");
                }
            }
           
        }

        //Update Developer Content
        private void UpdateExistingDeveloperContent()
        {
            DisplayListOfAllDevelopers();

            Console.WriteLine("Enter the Developer ID you would like to update.");

            string oldDeveloperAsString = Console.ReadLine();
            int oldDeveloperAsInt = int.Parse(oldDeveloperAsString);

            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the Updated name of the Developer:");
            newDeveloper.FullName = Console.ReadLine();

            Console.WriteLine("Enter Updated Developer Id:");
            string devIdAsString = Console.ReadLine();
            int devIdAsInt = int.Parse(devIdAsString);
            newDeveloper.DevId = devIdAsInt;
          

            Console.WriteLine("Enter Updated DevTeam Id:");
            string devTeamIdAsString = Console.ReadLine();
            int devTeamAsInt = int.Parse(devTeamIdAsString);
            newDeveloper.DevTeamId = devTeamAsInt;

            Console.WriteLine("Does the Developer have PluralSight Access? Y or N?");
            string hasPluralAccessString = Console.ReadLine().ToLower();
            if (hasPluralAccessString == "y")
            {
                newDeveloper.HasPluralsightAccess = true;
            }
            else
            {
                newDeveloper.HasPluralsightAccess = false;
            }
            


            bool wasUpdated = _contentDevRepo.UpdateListOfDevelopers(oldDeveloperAsInt, newDeveloper);
            if (wasUpdated)
            {
                Console.WriteLine("Developer was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }

            DisplayListOfAllDevelopers();



        }

        //Update DevTeam Content
        private void UpdateExistingDevTeamContent()
        {
            DisplayListOfAllDevTeams();

            List<Developer> devTeamMembers = new List<Developer>();

            Console.WriteLine("Enter the DevTeam ID you would like to update.");

            string oldDevTeamIdAsString = Console.ReadLine();
            int oldDevTeamIdAsInt = int.Parse(oldDevTeamIdAsString);

            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter Updated DevTeam Name:");

            newDevTeam.TeamName = Console.ReadLine();
            newDevTeam.TeamMembers = devTeamMembers;
            newDevTeam.TeamId = oldDevTeamIdAsInt;
            bool wasUpdated = _contentDevTeamRepo.UpdateCurrentListOfTeams(oldDevTeamIdAsInt, newDevTeam);
            if (wasUpdated)
            {
                Console.WriteLine("DevTeam was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update DevTeam.");
            }
            
            DisplayListOfAllDevTeams();
        }

        //Delete Existing Developer Content
        private void DeleteExistingDeveloperContent()
        {
            DisplayListOfAllDevelopers();

            Console.WriteLine("Enter the Developer ID you wish to delete:");
            string devIdAsString = Console.ReadLine();
            int devIdAsInt = int.Parse(devIdAsString);

            bool wasDeleted = _contentDevRepo.RemoveDeveloperFromList(devIdAsInt);

               if(wasDeleted)
            {
                Console.WriteLine("The Developer was successfully removed from the list.");
            }
            else
            {
                Console.WriteLine("The Developer could not be removed from the list.");
            }
        }

        //Delete Exisiting DevTeam Content
        private void DeleteExistingDevTeamContent()
        {
            DisplayListOfAllDevTeams();

            Console.WriteLine("Enter the DevTeam ID you wish to delete:");
            string devTeamIdAsString = Console.ReadLine();
            int devTeamIdAsInt = int.Parse(devTeamIdAsString);

            bool wasDeleted = _contentDevTeamRepo.RemoveContentFromList(devTeamIdAsInt);

            if (wasDeleted)
            {
                Console.WriteLine("The DevTeam was successfully removed from the list.");
            }
            else
            {
                Console.WriteLine("The DevTeam could not be removed from the list.");
            }

        }

        //Seed Method

        private void SeedDeveloperList()
        {
            Developer JohnSmith = new Developer("John Smith", 123, true, 1);
            Developer JulieBrown = new Developer("Julie Brown", 223, false, 2);
            Developer JackFrost = new Developer("Jack Frost", 443, false, 3);
            Developer JoanJett = new Developer("Joan Jett", 553, true, 1);

            _contentDevRepo.AddDevlopersToList(JohnSmith);
            _contentDevRepo.AddDevlopersToList(JulieBrown);
            _contentDevRepo.AddDevlopersToList(JackFrost);
            _contentDevRepo.AddDevlopersToList(JoanJett);
        }

        private void SeedDevTeamList()
        {
            Developer johnSmith = new Developer("John Smith", 123, true, 1);
            Developer joanJett = new Developer("Joan Jett", 553, true, 1);
            Developer julieBrown = new Developer("Julie Brown", 223, false, 2);
            Developer jackFrost = new Developer("Jack Frost", 443, false, 3);

            List<Developer> teamOne = new List<Developer>();
            teamOne.Add(johnSmith);
            teamOne.Add(joanJett);

            List<Developer> teamTwo = new List<Developer>();
            teamTwo.Add(julieBrown);

            List<Developer> teamThree = new List<Developer>();
            teamThree.Add(jackFrost);



            DevTeam codeBlue = new DevTeam("Code Blue", 1, teamOne);
            DevTeam codeGreen = new DevTeam("Code Green", 2, teamTwo);
            DevTeam codeRed = new DevTeam("Code Red", 3, teamThree);

            _contentDevTeamRepo.AddTeamToList(codeBlue);
            _contentDevTeamRepo.AddTeamToList(codeGreen);
            _contentDevTeamRepo.AddTeamToList(codeRed);

            
        }
    }
}
