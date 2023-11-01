using Leopotam.Ecs;
using UnityEngine;

using Prototype.Gameplay.Blocker;

namespace Prototype.Gameplay.Spawner
{
    public class SpawnerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnerComponent, BlockerComponent>.Exclude<BlockComponent> _spawnerFilter;

        public void Run()
        {
            foreach (var id in _spawnerFilter)
            {
                ref var  spawnerComponent = ref _spawnerFilter.Get1(id);
                ref var  blockerComponent = ref _spawnerFilter.Get2(id);
                ref var  prefab = ref spawnerComponent.prefab;

                int idSpawnTransform = Random.Range(0, spawnerComponent.transforms.Count);
                Transform spawnTransform = spawnerComponent.transforms[idSpawnTransform];
                Object.Instantiate(prefab, spawnTransform.position, spawnTransform.rotation, spawnerComponent.parentItems);

                _spawnerFilter.GetEntity(id).Get<BlockComponent>().Timer = blockerComponent.duration;
            }
        }
    }
}