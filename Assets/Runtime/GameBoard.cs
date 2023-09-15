using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class GameBoard : MonoBehaviour
    {
        [SerializeField] private List<Level> _levels;
        public static int CoinsCount { get; private set; }
        public static int CrystalsCount { get; private set; }

        public static event Action<int> OnCoinsChanged;
        public static event Action<int> OnCrystalsChanged;

        public static void AddCoins(int addedValue)
        {
            CoinsCount += addedValue;
            OnCoinsChanged?.Invoke(CoinsCount);
        }

        public static void AddCrystals(int addedValue)
        {
            CrystalsCount += addedValue;
            OnCrystalsChanged?.Invoke(CrystalsCount);
        }

        public static bool TryRemoveCoins(int removedValue)
        {
            if (CoinsCount - removedValue > 0)
            {
                CoinsCount -= removedValue;
                OnCoinsChanged?.Invoke(CoinsCount);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryRemoveCrystals(int removedValue)
        {
            if (CrystalsCount - removedValue > 0)
            {
                CrystalsCount -= removedValue;
                OnCoinsChanged?.Invoke(CrystalsCount);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}