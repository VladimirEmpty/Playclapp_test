using System;
using UnityEngine;

namespace Code
{
    public sealed class GameUpdater : MonoBehaviour
    {
        public event Action OnUpdate;

        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
