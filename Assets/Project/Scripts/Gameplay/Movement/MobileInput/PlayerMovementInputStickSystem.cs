using Leopotam.Ecs;

using Prototype.Gameplay.Player;
using Prototype.UI.Joystick;

namespace Prototype.Gameplay.Movement.MobileInput
{
    public class PlayerMovementInputStickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, DirectionComponent> _playerFilter;
        private readonly EcsFilter<PlayerComponent, JoystickComponent, StickDragComponent> _joystickFilter;
    
        public void Run()
        {
            ref var directionPlayer = ref _playerFilter.Get2(0).Direction;
            
            foreach (var id in _joystickFilter)
            {
                ref var directionComponent = ref _joystickFilter.Get2(id);
                ref var transform = ref directionComponent.transform;
                ref var transformStick = ref directionComponent.transformStick;

                float moveX = transformStick.position.x - transform.position.x;
                float moveZ = transformStick.position.y - transform.position.y;
                directionPlayer.x = moveX;
                directionPlayer.z = moveZ;
            }
        }
    }
}