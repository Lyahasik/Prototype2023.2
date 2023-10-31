using Leopotam.Ecs;

namespace Prototype.UI.Joystick
{
    public class JoystickInitSystem : IEcsInitSystem
    {
        private readonly EcsFilter<JoystickComponent> _joystickFilter;

        public void Init()
        {
            foreach (var id in _joystickFilter)
            {
                ref var joystickComponent = ref _joystickFilter.Get1(id);
                joystickComponent.transformStick.GetComponent<StickMovement>().EntityJoystick
                    = _joystickFilter.GetEntity(id);
            }
        }
    }
}