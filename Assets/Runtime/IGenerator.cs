using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public interface IGenerator
    {
        IEnumerator Generate();
    }
}