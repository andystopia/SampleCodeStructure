using ElementClickComponents;
using GlobalHoverComponents;
using UnityEngine;

namespace ElementHoverComponents
{
    // don't let anyone add this to their object directly.
    public abstract class HoverMediator : MonoBehaviour
    {
        [SerializeField]
        private GlobalHoverEventManager _eventManager;

        public GlobalHoverEventManager EventManager => _eventManager;
        
        private bool _isHovered;

        private ClickMediator _clickMediator;

        public bool IsHovered => ReferenceEquals(_eventManager.CurrentlyHovered, this);

        public ClickMediator AssociatedClickMediator => _clickMediator;

        protected virtual void Awake()
        {
            _clickMediator = GetComponent<ClickMediator>();
        }

        public virtual void HoverEnterRequested()
        {
            EventManager.BroadcastHoverEvent(this);
            _isHovered = true;
        }
        public virtual void HoverLeaveRequested()
        {
            _isHovered = false;
            EventManager.RemoveIfHovered(this);
        }

        public virtual void Invalidate(HoverMediator src)
        {
            if (src == this || !_isHovered) return;
            HoverLeaveRequested();
        }
    }
}