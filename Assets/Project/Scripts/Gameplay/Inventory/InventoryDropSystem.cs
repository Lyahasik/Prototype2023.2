using Leopotam.Ecs;
using UnityEngine;

using Prototype.Gameplay.Blocker;
using Prototype.Gameplay.Item;

namespace Prototype.Gameplay.Inventory
{
    public class InventoryDropSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemDropComponent> _itemDropFilter;
        private readonly EcsFilter<InventoryComponent, BlockerComponent>.Exclude<BlockComponent> _inventoryFilter;

        public void Run()
        {
            foreach (var id in _inventoryFilter)
            {
                if (_itemDropFilter.IsEmpty()) return;
            
                ref int numberItems = ref _inventoryFilter.Get1(id).NumberItems;
                ref float durationDrop = ref _inventoryFilter.Get2(id).duration;

                if (numberItems <= 0)
                {
                    _itemDropFilter.GetEntity(id).Del<ItemDropComponent>();
                    return;
                }
            
                numberItems--;
                Debug.Log($"Drop item. Number item: { numberItems }");
                _inventoryFilter.GetEntity(id).Get<BlockComponent>().Timer = durationDrop;
            }
        }
    }
}