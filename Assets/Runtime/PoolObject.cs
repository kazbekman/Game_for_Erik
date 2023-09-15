using UnityEngine;

namespace Runtime
{
    /// <summary>
    /// The object for creating a pool.
    /// </summary>
    public abstract class PoolObject : MonoBehaviour
    {
        /// <summary>
        /// Deactivate an PoolObject on the scene and return it to the pool.
        /// </summary>
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}