using Leopotam.Ecs;

using Prototype.Core.Pools;

namespace Prototype.Gameplay.Item
{
    public class ReturningItemsToPoolSystem : IEcsRunSystem
    {
        private readonly PoolItems _poolItems;
        
        private readonly EcsFilter<ItemTakenComponent, ItemRaisedComponent> _itemTakenFilter;
        
        public void Run()
        {
            foreach (var id in _itemTakenFilter)
            {
                ref var item = ref _itemTakenFilter.Get1(id).Item;

                _poolItems.ReturnItem(item);
            }
        }
    }
}