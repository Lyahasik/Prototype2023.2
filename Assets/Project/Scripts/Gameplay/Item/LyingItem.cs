using UnityEngine;
using Voody.UniLeo;

using Prototype.Core.Pools;
using Prototype.Helpers;

namespace Prototype.Gameplay.Item
{
    [RequireComponent(typeof(Collider))]
    public class LyingItem : MonoBehaviour
    {
        private PoolItems _poolItems;

        public PoolItems PoolItems
        {
            set => _poolItems = value;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            WorldHandler.GetWorld().NewEntity().AddComponent(new ItemTakenComponent());
            
            _poolItems.ReturnItem(this);
        }
    }
}
