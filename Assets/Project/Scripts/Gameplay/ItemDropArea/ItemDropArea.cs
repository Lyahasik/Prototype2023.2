using UnityEngine;
using Voody.UniLeo;

using Prototype.Gameplay.Item;
using Prototype.Helpers;

namespace Prototype.Gameplay.ItemDropArea
{
    [RequireComponent(typeof(Collider))]
    public class ItemDropArea : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            WorldHandler.GetWorld().NewEntity().AddComponent(new ItemDropComponent());
        }
    }
}
