using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class LootBox : PoolObject
    {
        [SerializeField] private List<Character> _dropOutCharacters;

        public event Action OnCharacterCreated;

        public void CreateCharacter()
        {
            int commonWeight = CalculateCommonWeight();
            foreach (Character character in _dropOutCharacters)
            {
                int tempRandom = UnityEngine.Random.Range(1, commonWeight + 1);
                if (character.Weight <= tempRandom)
                {
                    Instantiate(character);
                    OnCharacterCreated?.Invoke();
                    return;
                }
                else
                {
                    commonWeight -= character.Weight;
                }
            }
        }

        private int CalculateCommonWeight()
        {
            int commonWeight = 0;
            foreach (Character character in _dropOutCharacters)
            {
                commonWeight += character.Weight;
            }
            return commonWeight;
        }
    }
}