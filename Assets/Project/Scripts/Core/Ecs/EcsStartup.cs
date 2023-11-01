using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

using Prototype.Core.Pools;
using Prototype.Gameplay.Movement;
using Prototype.Gameplay.Movement.MobileInput;
using Prototype.Gameplay.Blocker;
using Prototype.Gameplay.Inventory;
using Prototype.Gameplay.Item;
using Prototype.Gameplay.Spawner;
using Prototype.UI.Joystick;

namespace Prototype.Core.Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private PoolItems poolItems;
        
        private EcsWorld _world;
        private EcsSystems _systems;
        
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddInjections();
            AddSystems();
            AddOneFrames();

            _systems.Init();
        }

        private void AddInjections()
        {
            _systems
                .Inject(poolItems);
        }

        private void AddOneFrames()
        {
            _systems
                .OneFrame<StickResetComponent>()
                .OneFrame<ItemTakenComponent>();
        }
        
        private void AddSystems()
        {
            _systems
                .Add(new SpawnerSystem())
                .Add(new JoystickInitSystem())
                .Add(new PlayerMovementInputStickSystem())
                .Add(new PlayerMovementResetStickSystem())
                .Add(new MovementSystem())
                .Add(new BlockerSystem())
                .Add(new InventoryTakenSystem())
                .Add(new InventoryDropSystem());
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