using System.Collections.Generic;
using UnityEngine;

using Prototype.Gameplay.Item;

namespace Prototype.Core.Pools
{
    public class PoolItems : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        
        private Stack<Item> _items;

        public Item GetItem()
        {
            _items ??= new Stack<Item>();
        
            if (_items.Count <= 0)
            {
                Item newItem = Instantiate(prefab, transform).GetComponent<Item>();
                
                return newItem;
            }
        
            Item item = _items.Pop();
            item.gameObject.SetActive(true);

            return item;
        }
    
        public void ReturnItem(Item item)
        {
            item.gameObject.SetActive(false);
            item.transform.parent = transform;
            item.transform.localPosition = Vector3.zero;
        
            _items.Push(item);
        }
    }
}
