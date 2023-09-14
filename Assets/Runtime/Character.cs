using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class Character : Entity
    {
        [SerializeField] private Element _firstElement;
        [SerializeField] private Element _secondElement;
        [SerializeField] private Element _thirdElement;
        [SerializeField] private int _coinsCount;

        [SerializeField] private float _speed;
        [SerializeField] private float _gravity;

        private void Update()
        {
            float deltaX = Input.GetAxis("Horizontal");
            Vector3 nextPosition = new Vector3(deltaX, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + nextPosition, _speed * Time.fixedDeltaTime);
        }
        public void Move()
        {
            float deltaX = Input.GetAxis("Horizontal");
            Vector3 nextPosition = new Vector3(deltaX, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + nextPosition, _speed * Time.fixedDeltaTime);
        }
    }
}