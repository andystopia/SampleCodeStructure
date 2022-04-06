using ElementHoverComponents;
using UnityEngine;

namespace ElementClickComponents
{
    [RequireComponent(typeof(HoverMediator))]
    public class ClickMediator : MonoBehaviour
    {
        protected HoverMediator _hoverMediator;
        protected IClickHandler[] _clickHandlers;

        protected virtual void Awake()
        {
            _hoverMediator = GetComponent<HoverMediator>();
            _clickHandlers = GetComponents<IClickHandler>();
        }
        public virtual void RequestClicked()
        {
            if (_hoverMediator.IsHovered)
            {
                foreach (var clickHandler in _clickHandlers)
                {
                    clickHandler.clicked();
                }
            }
        }

    }
}