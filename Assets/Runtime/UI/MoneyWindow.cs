using UnityEngine;
using Runtime;
using TMPro;

namespace UI
{
    public class MoneyWindow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsCount;
        [SerializeField] private TMP_Text _crystalsCount;

        private void Awake()
        {
            _coinsCount = GetComponentsInChildren<TMP_Text>()[0];
            _crystalsCount = GetComponentsInChildren<TMP_Text>()[1];
        }

        private void OnEnable()
        {
            GameBoard.OnCoinsChanged += ShowCoinsCount;
            GameBoard.OnCrystalsChanged += ShowCrystalsCount;
        }

        private void OnDisable()
        {
            GameBoard.OnCoinsChanged -= ShowCoinsCount;
            GameBoard.OnCrystalsChanged -= ShowCrystalsCount;
        }

        private void ShowCoinsCount(int value)
        {
            _coinsCount.text = value.ToString();
        }

        private void ShowCrystalsCount(int value)
        {
            _crystalsCount.text = value.ToString();
        }
    }
}