using Leopotam.Ecs;
using UnityEngine;

using Prototype.Gameplay.Item;

namespace Prototype.Gameplay.Inventory
{
    public class InventoryTakenSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemTakenComponent> _itemTakenFilter;
        private readonly EcsFilter<InventoryComponent> _inventoryFilter;

        public void Run()
        {
            foreach (var id in _itemTakenFilter)
            {
                ref int numberItems = ref _inventoryFilter.Get1(id).NumberItems;

                numberItems++;
                Debug.Log($"Take item. Number item: { numberItems }");
            }
        }
    }
}