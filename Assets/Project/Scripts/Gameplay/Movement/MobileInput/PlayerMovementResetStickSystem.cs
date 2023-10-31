using Leopotam.Ecs;
using Prototype.Gameplay.Player;
using Prototype.UI.Joystick;
using UnityEngine;

namespace Prototype.Gameplay.Movement.MobileInput
{
    public class PlayerMovementResetStickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, DirectionComponent> _playerFilter;
        private readonly EcsFilter<PlayerComponent, JoystickComponent, StickResetComponent> _joystickFilter;
    
        public void Run()
        {
            ref var directionPlayer = ref _playerFilter.Get2(0).Direction;
            
            foreach (var id in _joystickFilter)
            {
                directionPlayer = Vector3.zero;
            
                _joystickFilter.GetEntity(id).Del<StickDragComponent>();
            }
        }
    }
}