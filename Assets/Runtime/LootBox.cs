using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime
{
    public class LootBox : PoolObject, IPointerDownHandler
    {
        [SerializeField] private List<Character> _dropOutCharacters;
        private Level _parent;

        public event Action CharacterCreated;

        public void Init(Level parent)
        {
            _parent = parent;
        }
        public void CreateCharacter()
        {
            int commonWeight = CalculateCommonWeight();
            foreach (Character character in _dropOutCharacters)
            {
                int tempRandom = UnityEngine.Random.Range(1, commonWeight + 1);
                if (character.Weight <= tempRandom)
                {
                    Instantiate(character, _parent.transform);
                    CharacterCreated?.Invoke();
                    ReturnToPool();
                    return;
                }
                else
                {
                    commonWeight -= character.Weight;
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == 0)
            {
                CreateCharacter();
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