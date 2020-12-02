using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Repo
{
    public class Developer
    {
        public string FullName { get; set; }
        public int DevId { get; set; }
        public bool HasPluralsightAccess { get; set; }

        public int DevTeamId {get; set; }
        public static Developer developer { get; internal set; }

        public Developer() {}

        public Developer(string fullName, int devId, bool hasPluralAccess, int devteamId)
        {
            FullName = fullName;
            DevId = devId;
            HasPluralsightAccess = hasPluralAccess;
            DevTeamId = devteamId;

        }

    }
}
