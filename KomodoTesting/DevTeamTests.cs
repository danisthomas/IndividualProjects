using DevTeams_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoTesting
{
    [TestClass]
    public class DevTeamTests
    {
        [TestMethod]
        public void SetDevTeamName_ShouldSetCorrectString()
        {

            DevTeam devteam = new DevTeam();

            devteam.TeamName = "Crazy Guys";

            string expected = "Crazy Guys";
            string actual = devteam.TeamName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetDevTeamId_ShouldSetCorrectInt()
        {
            DevTeam devteam = new DevTeam();

            devteam.TeamId = 3;

            int expected = 3;
            int actual = devteam.TeamId;

            Assert.AreEqual(expected, actual);
        }
       
    }
}
