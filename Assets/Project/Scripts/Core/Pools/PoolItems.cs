using System.Collections.Generic;
using UnityEngine;

using Prototype.Gameplay.Item;

namespace Prototype.Core.Pools
{
    public class PoolItems : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        
        private Stack<LyingItem> _items;

        public LyingItem GetItem()
        {
            _items ??= new Stack<LyingItem>();
        
            if (_items.Count <= 0)
            {
                LyingItem newItem = Instantiate(prefab, transform).GetComponent<LyingItem>();
                newItem.PoolItems = this;
                
                return newItem;
            }
        
            LyingItem item = _items.Pop();
            item.gameObject.SetActive(true);

            return item;
        }
    
        public void ReturnItem(LyingItem item)
        {
            item.gameObject.SetActive(false);
            item.transform.parent = transform;
            item.transform.localPosition = Vector3.zero;
        
            _items.Push(item);
        }
    }
}
