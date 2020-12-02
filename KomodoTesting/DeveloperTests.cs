using Developer_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoTesting
{
    [TestClass]
    public class DeveloperTests
    {
        [TestMethod]
        public void SetDeveloperName_ShouldSetCorrectstring()

        {
            Developer developer = new Developer();

            developer.FullName = "Daniele Thomas";

            string expected = "Daniele Thomas";
            string actual = developer.FullName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetDevId_ShouldSetCorrectInt()
        {
            Developer developer = new Developer();
            developer.DevId = 1234;

            int expected = 1234;
            int actual = developer.DevId;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SetPluralSigtAccess_ShouldSetCorrectBool()
        {
            Developer developer = new Developer();
            developer.HasPluralsightAccess = true;

            bool expected = true;
            bool actual = developer.HasPluralsightAccess;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetDevTeamId_ShouldSetCorrectInt()
        {
            Developer developer = new Developer();
            developer.DevTeamId = 2;

            int expected = 2;
            int actual = developer.DevTeamId;

            Assert.AreEqual(expected, actual);

        }

    }
}
