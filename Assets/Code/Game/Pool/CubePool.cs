using UnityEngine;

using Code.Pool;

namespace Code.Game.Pool
{
    public sealed class CubePool : BaseGameObjectPool<GameObject>
    {
        public CubePool(GameObject prototype) : base(prototype) { }

        public GameObject Spawn(Vector3 position)
        {
            var cube = base.Spawn();
            cube.transform.position = position;

            return cube;
        }

        protected override void OnDespawn(GameObject despawnedObject)
        {
            despawnedObject.SetActive(false);      
        }

        protected override void OnSpawn(GameObject spawnedObject)
        {
            spawnedObject.SetActive(true);
        }
    }
}
