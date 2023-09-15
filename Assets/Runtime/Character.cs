using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class Character : Entity, IGenerator
    {
        [SerializeField] private Element _hair;
        [SerializeField] private Element _head;
        [SerializeField] private Element _body;
        [SerializeField] private int _coinsForTick;
        [SerializeField] private float _generateSpeed;
        [Min(1)] [SerializeField] private int _evolution;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _gravity;
        [SerializeField] private int _weight;


        public int Evolution => _evolution;
        public int CoinsForTick => _coinsForTick * Evolution;
        public float GenerateSpeed => _generateSpeed;
        public int Weight => _weight;

        private void OnEnable()
        {
            StartCoroutine(Generate());
        }

        private void OnDisable()
        {
            StopCoroutine(Generate());
        }

        public IEnumerator Generate()
        {
            while (gameObject.activeInHierarchy)
            {
                GameBoard.AddCoins(CoinsForTick);
                yield return new WaitForSeconds(GenerateSpeed);
            }
        }
    }
}