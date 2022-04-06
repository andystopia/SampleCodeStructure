using UnityEngine;

namespace ElementHoverComponents
{
    [RequireComponent(typeof(HoverMediator))]
    public class MouseHoverSource : MonoBehaviour
    {
        private HoverMediator _mediator;

        protected virtual void Awake()
        {
            _mediator = GetComponent<HoverMediator>();
        }

        protected virtual void OnMouseEnter()
        {
            _mediator.HoverEnterRequested();
        }
    
        protected virtual void OnMouseExit()
        {
            _mediator.HoverLeaveRequested();
        }
    
    
    }
}