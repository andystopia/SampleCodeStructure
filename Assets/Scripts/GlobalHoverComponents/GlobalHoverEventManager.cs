using ElementHoverComponents;
using UnityEngine;

namespace GlobalHoverComponents
{
    public class GlobalHoverEventManager : MonoBehaviour
    {
        private HoverMediator _currentlyHovered = null;

        public HoverMediator CurrentlyHovered => _currentlyHovered;

        public void BroadcastHoverEvent(HoverMediator src)
        {
            if (_currentlyHovered != null)
            {
            
                _currentlyHovered.Invalidate(src);
            }

            _currentlyHovered = src;
        }

        public void RemoveIfHovered(HoverMediator hoverMediator)
        {
            if (ReferenceEquals(hoverMediator, CurrentlyHovered))
            {
                _currentlyHovered = null;
            }
        }
    }
}