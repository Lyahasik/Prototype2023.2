using Leopotam.Ecs;
using UnityEngine;

using Prototype.Gameplay.Blocker;
using Prototype.Gameplay.Inventory;
using Prototype.Gameplay.Item;
using Prototype.Gameplay.Player;

namespace Prototype.Gameplay.ItemDropArea
{
    public class DropAreaSystem : IEcsRunSystem
    {
        private readonly UI.Inventory.Inventory _inventory;
        
        private readonly EcsFilter<ItemDropComponent> _itemDropFilter;
        private readonly EcsFilter<PlayerComponent, InventoryComponent, BlockerComponent>.Exclude<BlockComponent> _inventoryFilter;

        public void Run()
        {
            if (_itemDropFilter.IsEmpty()) return;
            
            foreach (var id in _inventoryFilter)
            {
                ref int numberItems = ref _inventoryFilter.Get2(id).NumberItems;
                ref float durationDrop = ref _inventoryFilter.Get3(id).duration;

                if (numberItems <= 0)
                {
                    _itemDropFilter.GetEntity(id).Del<ItemDropComponent>();
                    return;
                }
            
                numberItems--;
                _inventory.UpdateItems(numberItems);
                Debug.Log($"Drop item. Number item: { numberItems }");
                _inventoryFilter.GetEntity(id).Get<BlockComponent>().Timer = durationDrop;
            }
        }
    }
}