using Developer_Repo;
using DevTeams_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoTesting
{
    [TestClass]
    public class Devteam_RepositoryTests
    {
        private DevTeam_Repository _repo;
        private DevTeam _content;
        
        

        [TestInitialize]
        public void Arrange()
        {
            
            Developer johnSmith = new Developer("John Smith", 123, true, 1);
            Developer joanJett = new Developer("Joan Jett", 553, true, 1);
            List<Developer> teamOne = new List<Developer>();
            teamOne.Add(johnSmith);
            teamOne.Add(joanJett);

            _repo = new DevTeam_Repository();
            _content = new DevTeam("Code Magenta", 2, teamOne);

            _repo.AddTeamToList(_content);

        }


        [TestMethod]
        public void AddToList_ShouldGetNull()
        {
            //Arrange
            DevTeam content = new DevTeam();
            content.TeamId = 3;
            DevTeam_Repository repository = new DevTeam_Repository();

            //Act
            repository.AddTeamToList(content);
            DevTeam contentFromDirectory = repository.GetTeamByDevTeamId(3);

            //Assert
            Assert.IsNotNull(contentFromDirectory);

           
        }

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            Developer johnSmith = new Developer("John Smith", 123, true, 1);
            Developer joanJett = new Developer("Joan Jett", 553, true, 1);
            List<Developer> teamOne = new List<Developer>();
            teamOne.Add(johnSmith);
            teamOne.Add(joanJett);

            //Test Initialize
            DevTeam newContent = new DevTeam("Code Orange", 5, teamOne);
            //Act
            bool updateResult = _repo.UpdateCurrentListOfTeams(2, newContent);

            //Assert

            Assert.IsTrue(updateResult);

        }
        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(3, false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(int originalDevTeamId, bool shouldUpdate)
        {
            //Arrange
            Developer johnSmith = new Developer("John Smith", 123, true, 1);
            Developer joanJett = new Developer("Joan Jett", 553, true, 1);
            List<Developer> teamOne = new List<Developer>();
            teamOne.Add(johnSmith);
            teamOne.Add(joanJett);

            //Test Initialize
            DevTeam newContent = new DevTeam("Code Orange", 5, teamOne);
            //Act
            bool updateResult = _repo.UpdateCurrentListOfTeams(originalDevTeamId, newContent);

            //Assert

            Assert.AreEqual(shouldUpdate, updateResult);

        }
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange
            //ACT
            bool deleteResult = _repo.RemoveContentFromList(_content.TeamId);

            Assert.IsTrue(deleteResult);
        }
    }
}
