using System;

using Code.Factory;

namespace Code.Pool
{
    public interface IPool<T> : IContainablePool
        where T : UnityEngine.Object
    {
        IFactory<T> Factory { get; }

        public T Spawn();
        public void Despawn(T despawnedObject);
    }
}
