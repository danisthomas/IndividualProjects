using Developer_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoTesting
{
    [TestClass]
    public class Developer_RespositoryTests
    {
        private Developer_Repository _repo;
        private Developer _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new Developer_Repository();
            _content = new Developer("Daniele Thomas", 112, true, 3);

            _repo.AddDevlopersToList(_content);
        }

        //Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull ()
        {   //Arrange
            Developer content = new Developer();
            content.FullName = "Daniele Thomas";
            Developer_Repository repository = new Developer_Repository();
            //Act
            repository.AddDevlopersToList(content);
            Developer contentFromDirectory = repository.GetDeveloperByDeveloperName("Daniele Thomas");
            //Assert
            Assert.IsNotNull(contentFromDirectory);
        }

        //Update
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
            Developer newContent = new Developer("Julie Marks", 223, false, 2);

            //Act
            bool updateResult = _repo.UpdateListOfDevelopers(112, newContent);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow(112, true)]
        [DataRow(123, false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(int originalDevId, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            Developer newContent = new Developer("Julie Marks", 223, false, 2);

            //Act
            bool updateResult = _repo.UpdateListOfDevelopers(originalDevId, newContent);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange
            //Act

            bool deleteResult = _repo.RemoveDeveloperFromList(_content.DevId);

            Assert.IsTrue(deleteResult);
        }
    }

}
