using System;
using System.Collections;
using UnityEngine;

namespace Runtime
{
    public abstract class Level : MonoBehaviour
    {
        [SerializeField] private Element _element;

        [Range(5, 10)]
        [SerializeField] protected int maxCharactersCount;

        [SerializeField] protected int currentCharactersCount;

        [SerializeField] private int _levelNumber;

        protected Pool pool;

        public int LevelNumber => _levelNumber;

        public int NextLevel => ++_levelNumber;

        public void SetLevel(int levelNumber)
        {
            _levelNumber = levelNumber;
        }
    }
}