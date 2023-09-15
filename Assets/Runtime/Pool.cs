using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private PoolObject _prefab;
        [SerializeField] private Transform _container;
        [SerializeField] private int _minCapacity;
        [SerializeField] private int _maxCapasity;
        [SerializeField] private bool _autoExpand;


        private Queue<PoolObject> _objectsPool;

        private void OnValidate()
        {
            if (_autoExpand)
            {
                _maxCapasity = int.MaxValue;
            }
        }
        private void Awake()
        {
            CreatePool();
        }
        private void CreatePool()
        {
            _objectsPool = new Queue<PoolObject>(_minCapacity);
            for (int index = 0; index < _minCapacity; index++)
            {
                CreateElement();
            }
        }

        private PoolObject CreateElement(bool isActiveByDefault = false)
        {
            PoolObject createdObject = Instantiate(_prefab, _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _objectsPool.Enqueue(createdObject);
            return createdObject;
        }
        public bool TryGetElement(out PoolObject element)
        {
            foreach (PoolObject item in _objectsPool)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }
            element = null;
            return false;
        }

        public PoolObject GetFreeElement()
        {
            if (TryGetElement(out PoolObject element))
                return element;
            else if (_autoExpand || _objectsPool.Count < _maxCapasity)
                return CreateElement(true);
            else
                throw new InvalidCastException("Pool is over!");
        }

        public PoolObject GetFreeElement(Vector3 position)
        {
            PoolObject element = GetFreeElement();
            element.transform.position = position;
            return element;
        }

        public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
        {
            PoolObject element = GetFreeElement(position);
            element.transform.rotation = rotation;
            return element;
        }
    }
}