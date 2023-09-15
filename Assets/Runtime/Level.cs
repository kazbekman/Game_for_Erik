using System.Collections;
using UnityEngine;

namespace Runtime
{
    public abstract class Level : MonoBehaviour
    {
        [SerializeField] private Element _element;

        [Range(5, 10)]
        [SerializeField] private int _maxCharactersCount;

        protected Pool pool;
    }
}