using UnityEngine;

using Code.StateMachine;
using Code.StateMachine.State;
using Code.Game.Other;

namespace Code.Game.State
{
    public sealed class CubeMovementState : BaseState<CubeObject>
    {
        private float _destroyDistance;

        public override bool IsUpdatable => true;

        public override void Enter()
        {
            _destroyDistance = StateOwner.CubeGameObject.transform.position.y + StateOwner.Distance;
        }

        public override void Update()
        {
            StateOwner.CubeGameObject.transform.Translate(Vector3.up * StateOwner.Speed * Time.deltaTime);

            if (StateOwner.CubeGameObject.transform.position.y >= _destroyDistance)
                Exit();

        }

        public override void Exit()
        {
            StateOwner.Destroy();
        }
    }
}
