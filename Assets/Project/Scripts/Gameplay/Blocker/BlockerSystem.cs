using Leopotam.Ecs;
using UnityEngine;

namespace Prototype.Gameplay.Blocker
{
    public class BlockerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockerComponent, BlockComponent> _blockerFilter;

        public void Run()
        {
            foreach (var id in _blockerFilter)
            {
                ref float timer = ref _blockerFilter.Get2(id).Timer;

                timer -= Time.deltaTime;
                if (timer <= 0f)
                    _blockerFilter.GetEntity(id).Del<BlockComponent>();
            }
        }
    }
}