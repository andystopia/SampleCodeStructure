using UnityEngine;

namespace ElementHoverComponents.HoverEffects
{
    public class ColorHoverDisplay : MonoBehaviour, IHoverBehaviour
    {
        [SerializeField] private Color _unHoverColor;
        [SerializeField] private Color _hoverColor;
        private SpriteRenderer _renderer;
    
        protected virtual void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        protected virtual void Start()
        {
            _renderer.color = _unHoverColor;
        }
    
    
        public void OnHoverEnter()
        {
            _renderer.color = _hoverColor;
        }

        public void OnHoverLeave()
        {
            _renderer.color = _unHoverColor;
        }
    }
}
