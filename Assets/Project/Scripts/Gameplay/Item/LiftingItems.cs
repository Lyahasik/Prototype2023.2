using UnityEngine;
using Voody.UniLeo;

using Prototype.Helpers;

namespace Prototype.Gameplay.Item
{
    public class LiftingItems : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Item item = other.GetComponent<Item>();
            if (!item) return;
            
            WorldHandler.GetWorld().NewEntity().AddComponent(new ItemTakenComponent
            {
                Item = item
            });
        }
    }
}
