using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

using Prototype.Gameplay.Movement;

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
            
            AddSystems();
        
            _systems.Init();
        }
        
        private void AddSystems()
        {
            _systems
                .Add(new PlayerMovementInputSystem())
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