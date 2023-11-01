using Leopotam.Ecs;
using UnityEngine;

using Prototype.Core.Pools;
using Prototype.Gameplay.Blocker;
using Prototype.Gameplay.Item;

namespace Prototype.Gameplay.Spawner
{
    public class SpawnerSystem : IEcsRunSystem
    {
        private readonly PoolItems _poolItems;
        
        private readonly EcsFilter<SpawnerComponent, BlockerComponent>.Exclude<BlockComponent> _spawnerFilter;

        public void Run()
        {
            foreach (var id in _spawnerFilter)
            {
                ref var  spawnerComponent = ref _spawnerFilter.Get1(id);
                ref var  blockerComponent = ref _spawnerFilter.Get2(id);
                ref var  prefab = ref spawnerComponent.prefab;
                
                LyingItem item = _poolItems.GetItem();
                item.transform.parent = spawnerComponent.parentItems;
                
                int idSpawnTransform = Random.Range(0, spawnerComponent.transforms.Count);
                Transform spawnTransform = spawnerComponent.transforms[idSpawnTransform];
                item.transform.position = spawnTransform.position;

                _spawnerFilter.GetEntity(id).Get<BlockComponent>().Timer = blockerComponent.duration;
            }
        }
    }
}