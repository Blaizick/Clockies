using System.Collections;
using UnityEngine;

namespace Clockies
{
    public class SceneInjection : MonoBehaviour
    {
        public void _StartCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }
    }
}
