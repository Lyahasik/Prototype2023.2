using UnityEngine;
using Voody.UniLeo;

using Prototype.Helpers;

namespace Prototype.Gameplay.Item
{
    [RequireComponent(typeof(Collider))]
    public class LyingItem : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            WorldHandler.GetWorld().NewEntity().AddComponent(new ItemTakenComponent());
            
            Destroy(gameObject);
        }
    }
}
