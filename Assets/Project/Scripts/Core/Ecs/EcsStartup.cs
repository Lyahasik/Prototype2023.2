using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

using Prototype.Gameplay.Movement;
using Prototype.Gameplay.Movement.MobileInput;
using Prototype.UI.Joystick;

namespace Prototype.Core.Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();
            
            AddOneFrames();
            AddSystems();

            _systems.Init();
        }

        private void AddOneFrames()
        {
            _systems
                .OneFrame<StickResetComponent>();
        }
        
        private void AddSystems()
        {
            _systems
                .Add(new JoystickInitSystem())
                .Add(new PlayerMovementInputStickSystem())
                .Add(new MovementSystem());
        }
        
        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _systems = null;
        
            _world.Destroy();
            _world = null;
        }
    }
}