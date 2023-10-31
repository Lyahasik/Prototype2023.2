using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Prototype.UI.Joystick
{
    public class StickMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private RectTransform _rectTransform;
        
        private Vector2 _beginPosition;
        [SerializeField] private float range;
        
        public EcsEntity EntityJoystick;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _beginPosition = _rectTransform.position;
        }

        private void Reset()
        {
            _rectTransform.position = _beginPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 direction = eventData.position - _beginPosition;
            direction = Vector3.ClampMagnitude(direction, range);

            _rectTransform.position = _beginPosition + direction;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            EntityJoystick.Get<StickDragComponent>();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            EntityJoystick.Get<StickResetComponent>();
            Reset();
        }
    }
}
