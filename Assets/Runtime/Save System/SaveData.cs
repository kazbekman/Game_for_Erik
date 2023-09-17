using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    [Serializable]
    public class SaveData
    {
        public int OpenLevelsCount;
        public int CoinsCount;
        public int CrystalsCount;

        public List<LevelData> AllLevels;
        public List<TowerData> AllTowers;
    }

    public class LevelData
    {
        public int LevelNumber;
        public int CurrentCharactersCount;
    }

    public class TowerData
    {
        public int TowerLevel;
    }
}