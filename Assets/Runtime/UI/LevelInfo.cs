using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Runtime;

namespace UI
{
    public class LevelInfo : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelNumber;
        [SerializeField] private Level _instance;

        private void Awake()
        {
            _levelNumber = GetComponent<TMP_Text>();
            _instance = GetComponentInParent<Level>();
        }

        private void OnEnable()
        {
            Show();
        }

        public void Show()
        {
            _levelNumber.text = _instance.LevelNumber.ToString();
        }    
    }
}