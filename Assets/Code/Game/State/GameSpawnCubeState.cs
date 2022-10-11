using UnityEngine;

using Code.StateMachine.State;
using Code.Game.Service;

namespace Code.Game.State
{
    public sealed class GameSpawnCubeState : BaseState<CubeService>
    {
        private float _timer;

        public override bool IsUpdatable => true;

        public override void Update()
        {
            _timer += Time.deltaTime;

            if(_timer >= StateOwner.CubeSpawnData.SpawnTime)
            {
                StateOwner.CreateCube();
                _timer = default;
            }            
        }
    }
}
