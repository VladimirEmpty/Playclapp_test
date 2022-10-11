using UnityEngine;

using Code.StateMachine;
using Code.Service;
using Code.Game.Pool;
using Code.Game.Other;
using Code.Game.State;

namespace Code.Game.Service
{
    public sealed partial class CubeService : IService, IStateMachineOwner
    {
        private readonly Transform CubeSpawnPoint;
        private readonly CubePool CubePool;

        public CubeService(
            Transform cubeSpawnPoint,
            CubePool cubePool)
        {
            CubeSpawnPoint = cubeSpawnPoint;
            CubePool = cubePool;

            CubeSpawnData = new CubeSpawnData(1, 1, 1);

            this.ChangeState<GameSpawnCubeState>(state => state.StateOwner = this);
        }

        public CubeSpawnData CubeSpawnData { get; private set; }
        public int Hash => GetHashCode();

        public void SetCubeSpawnData(CubeSpawnData data) => CubeSpawnData = data;

        public void CreateCube()
        {
            var cubeObject = new CubeObject(
                                    CubePool.Spawn(CubeSpawnPoint.position),
                                    CubeSpawnData.Speed,
                                    CubeSpawnData.Distance);
            
            cubeObject.OnDestroy += DestroyCube;
        }

        private void DestroyCube(CubeObject cubeObject)
        {
            CubePool.Despawn(cubeObject.CubeGameObject);
            cubeObject.OnDestroy -= DestroyCube;
            cubeObject.RemoveStateMachine();
            cubeObject.Dispose();
        }
    }
}
