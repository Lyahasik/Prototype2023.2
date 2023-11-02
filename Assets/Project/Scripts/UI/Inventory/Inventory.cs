using System.Collections.Generic;
using UnityEngine;

namespace Prototype.UI.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Slot> slots;

        private void Start()
        {
            UpdateItems(0);
        }

        public void UpdateItems(int numberItems)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (i < numberItems)
                    slots[i].Activate();
                else
                    slots[i].Deactivate();
            }
        }
    }
}
