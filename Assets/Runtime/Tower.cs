using System;
using System.Collections;
using UnityEngine;

namespace Runtime
{
    public class Tower : Level, IGenerator
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _coinsForUpgrade;
        [Min(1)]
        [SerializeField] private int _level;
        [Range(1f, 20f)]
        [SerializeField] private float _generateTime;

        public int CoinsForUpgrade => _coinsForUpgrade * _level;
        public int Level => _level;
        public float GenerateTime => _generateTime;

        public event Action OnTowerUpgraded;

        private void Awake()
        {
            _sprite = GetComponent<Sprite>();
            pool = GetComponent<Pool>();
        }
        private void OnEnable()
        {
            StartCoroutine(Generate());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public IEnumerator Generate()
        {
            while (gameObject.activeInHierarchy)
            {
                if (currentCharactersCount <= maxCharactersCount)
                {
                    LootBox lootBox = pool.GetFreeElement() as LootBox;
                    lootBox.Init(this);
                    yield return new WaitForSeconds(_generateTime);
                }
                yield return null;
            }
        }

        public void TryToUpgrade()
        {
            if (GameBoard.TryRemoveCoins(CoinsForUpgrade))
            {
                _level++;
                _generateTime -= _generateTime * 0.02f;
                OnTowerUpgraded?.Invoke();
            }
            else
            {
                Debug.Log("Не хватает денег!");
            }
        }
    }
}