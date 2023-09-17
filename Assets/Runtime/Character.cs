using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime
{
    public class Character : Entity, IGenerator, IPointerDownHandler, IBeginDragHandler, IDragHandler,
        IEndDragHandler, IDropHandler
    {
        [SerializeField] private Element _hair;
        [SerializeField] private Element _head;
        [SerializeField] private Element _body;
        [SerializeField] private int _coinsForTick;
        [SerializeField] private float _generateSpeed;
        [Min(1)][SerializeField] private int _evolution;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _gravity = 1;
        [SerializeField] private int _weight;

        private bool _isMoving = true;
        private Vector2 _direction = Vector2.right;
        private Collider2D _collider;
        private Rigidbody2D _rigidbody2D;

        public int Evolution => _evolution;
        public int CoinsForTick => _coinsForTick * Evolution;
        public float GenerateSpeed => _generateSpeed;
        public int Weight => _weight;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = _gravity;
        }

        private void OnEnable()
        {
            StartCoroutine(Generate());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
        private void FixedUpdate()
        {
            Move(_movementSpeed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _direction = SetDirection();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == 0)
            {
                GameBoard.AddCoins(CoinsForTick);
            }
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            _isMoving = false;
            _collider.isTrigger = true;
            _rigidbody2D.gravityScale = 0;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isMoving = true;
            _collider.isTrigger = false;
            _rigidbody2D.gravityScale = _gravity;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.GetType() == gameObject.GetType())
            {
                Merge();
                _collider.isTrigger = false;
            }
        }

        public IEnumerator Generate()
        {
            while (gameObject.activeInHierarchy)
            {
                GameBoard.AddCoins(CoinsForTick);
                yield return new WaitForSeconds(GenerateSpeed);
            }
        }

        private void Move(float speed)
        {
            if (_isMoving == true)
            {
                transform.Translate(_direction * speed * Time.fixedDeltaTime);
            }
        }

        private Vector2 SetDirection()
        {
            return _direction *= -1;
        }

        private void Merge()
        {
            
        }
    }
}