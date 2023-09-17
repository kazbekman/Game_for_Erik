using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Runtime;

namespace UI
{
    public class TowerWindow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsForUpgrade;
        [SerializeField] private Tower _parent;

        private void Awake()
        {
            _coinsForUpgrade = GetComponent<TMP_Text>();
            _parent = GetComponentInParent<Tower>();
        }

        private void OnEnable()
        {
            if (_parent != null)
                _parent.OnTowerUpgraded += Show;
        }

        private void OnDisable()
        {
            if (_parent != null)
                _parent.OnTowerUpgraded -= Show;
        }

        public void Show()
        {
            _coinsForUpgrade.text = $"{_parent.CoinsForUpgrade}\n{_parent.Level}";
        }
    }
}