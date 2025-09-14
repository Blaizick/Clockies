using System;
using System.Collections;
using UnityEngine;

namespace Clockies
{
    public class SceneInjection : MonoBehaviour
    {
        public Action onApplicationQuit;

        private void OnApplicationQuit()
        {
            onApplicationQuit?.Invoke();
        }
    }
}
