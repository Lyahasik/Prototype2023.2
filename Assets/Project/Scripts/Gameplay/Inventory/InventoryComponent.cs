using System;
using UnityEngine;

namespace Prototype.Gameplay.Inventory
{
    [Serializable]
    public struct InventoryComponent
    {
        public int maxItems;
        [HideInInspector] public int NumberItems;
    }
}