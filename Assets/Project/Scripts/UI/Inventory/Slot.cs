using UnityEngine;
using UnityEngine.UI;

namespace Prototype.UI.Inventory
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image itemImage;

        public void Activate()
        {
            itemImage.color = Color.blue;
        }
        
        public void Deactivate()
        {
            itemImage.color = Color.clear;
        }
    }
}
