using Leopotam.Ecs;
using UnityEngine;

namespace Prototype.Gameplay.Movement
{
    public class MovementSystem : IEcsRunSystem
    {
        private const float NormalStep = 1f;
        
        private readonly EcsWorld _world;
        private readonly EcsFilter<TransformComponent, MovementComponent, DirectionComponent> _movementFilter;

        public void Run()
        {
            foreach (var id in _movementFilter)
            {
                ref var transformComponent = ref _movementFilter.Get1(id);
                ref var movementComponent = ref _movementFilter.Get2(id);
                ref var directionComponent = ref _movementFilter.Get3(id);

                ref var direction = ref directionComponent.Direction;
                ref var transform = ref transformComponent.transform;

                ref var characterController = ref movementComponent.characterController;
                ref var speed = ref movementComponent.speed;

                var stepDirection = (transform.right * direction.x) + (transform.forward * direction.z);
                stepDirection = Vector3.ClampMagnitude(stepDirection, NormalStep);
                
                characterController.Move(stepDirection * speed * Time.deltaTime);
            }
        }
    }
}