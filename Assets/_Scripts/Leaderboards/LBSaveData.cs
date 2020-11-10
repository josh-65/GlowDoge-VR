using System;
using System.Collections.Generic;

namespace HomeJC.leaderboards
{
    [Serializable]
    public class LBSaveData
    {
        public List<LBEntryData> score = new List<LBEntryData>();
    }
}