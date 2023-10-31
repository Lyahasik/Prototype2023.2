using Leopotam.Ecs;
using UnityEngine;

namespace Prototype.Gameplay.Movement.KeyboardInput
{
    public class PlayerMovementInputKeyboardSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DirectionComponent> _directionFilter;

        private float _moveX;
        private float _moveZ;
    
        public void Run()
        {
            SetDirection();
        
            foreach (var id in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get1(id);
                ref var direction = ref directionComponent.Direction;

                direction.x = _moveX;
                direction.z = _moveZ;
            }
        }

        private void SetDirection()
        {
            _moveX = Input.GetAxis("Horizontal");
            _moveZ = Input.GetAxis("Vertical");
        }
    }
}