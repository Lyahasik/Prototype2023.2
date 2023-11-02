using Leopotam.Ecs;
using UnityEngine;

using Prototype.Gameplay.Item;
using Prototype.Gameplay.Player;

namespace Prototype.Gameplay.Inventory
{
    public class PlayerInventoryTakenSystem : IEcsRunSystem
    {
        private readonly UI.Inventory.Inventory _inventory;
        
        private readonly EcsFilter<ItemTakenComponent> _itemTakenFilter;
        private readonly EcsFilter<PlayerComponent, InventoryComponent> _inventoryFilter;

        public void Run()
        {
            if (_itemTakenFilter.IsEmpty()) return;
            
            foreach (var id in _inventoryFilter)
            {
                ref var inventoryComponent = ref _inventoryFilter.Get2(id);
                ref int maxItems = ref inventoryComponent.maxItems;
                ref int numberItems = ref inventoryComponent.NumberItems;
                
                if (numberItems >= maxItems) continue;

                numberItems++;
                _inventory.UpdateItems(numberItems);
                _itemTakenFilter.GetEntity(0).Get<ItemRaisedComponent>();
                Debug.Log($"Take item. Number item: { numberItems }");
            }
        }
    }
}