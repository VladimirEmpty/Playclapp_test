using System;
using UnityEngine;

using Code.StateMachine;
using Code.Game.State;

namespace Code.Game.Other
{
    public sealed class CubeObject : IDisposable, IStateMachineOwner
    {        
        private bool _isDisposed;

        public CubeObject(
            GameObject cubeGameObject,
            float speed,
            float distance)
        {
            CubeGameObject = cubeGameObject;
            Speed = speed;
            Distance = distance;

            this.ChangeState<CubeMovementState>(state => state.StateOwner = this);
        }

        public GameObject CubeGameObject { get; private set; }
        public int Hash => GetHashCode();
        public float Speed { get; }
        public float Distance { get; }

        public Action<CubeObject> OnDestroy;

        public void Destroy() => OnDestroy?.Invoke(this);

        public void Dispose()
        {
            if (_isDisposed) return;

            CubeGameObject = null;
            _isDisposed = true;

            GC.SuppressFinalize(this);
        }
    }
}
