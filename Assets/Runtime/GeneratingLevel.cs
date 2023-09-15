using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class GeneratingLevel : Level, IGenerator
    {
        public Vector3 RandomPosition
        {
            get
            {
                float xPosition = Random.Range(transform.localPosition.x, transform.localPosition.y);
                float yPosition = Random.Range(transform.localPosition.x, transform.localPosition.y);
                return new Vector3(xPosition, yPosition, 0);
            }
        }

        public Quaternion RandomRotation
        {
            get
            {
                return new Quaternion();
            }
        }
        public IEnumerator Generate()
        {
            throw new System.NotImplementedException();
        }
    }
}