using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class GameBoard : MonoBehaviour
    {
        [SerializeField] private List<Level> _levels;
        [SerializeField] private int _openLevelsCount;

        public static int CoinsCount { get; private set; }
        public static int CrystalsCount { get; private set; }

        public static event Action<int> OnCoinsChanged;
        public static event Action<int> OnCrystalsChanged;

        private void Awake()
        {
            for (int i = 0; i < _levels.Count; i++)
            {
                if (i < _openLevelsCount)
                    _levels[i].gameObject.SetActive(true);
                else
                    _levels[i].gameObject.SetActive(false);
                _levels[i].SetLevel(i + 1);
                Vector3 levelPosition = new Vector3(0, _levels[i].transform.localScale.y * i);
                Instantiate(_levels[i], _levels[i].transform.position + levelPosition, Quaternion.identity, transform);
            }
        }

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