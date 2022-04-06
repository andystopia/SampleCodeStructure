using Animation;
using UnityEngine;
using AnimationState = Animation.AnimationState;

namespace ElementHoverComponents.HoverEffects
{
    public class SmoothScaleHoverDisplay : MonoBehaviour, IHoverBehaviour
    {
        [SerializeField] private float _scaleFactor = 0.05f;
        [SerializeField] private int _animationFrameCount = 10;
        [SerializeField] private AnimationCurve _animationCurve;

        private VectorAnimator _vectorAnimator;
    
        private Vector3 _startingScale;

        protected virtual void Awake()
        {
            var localScale = transform.localScale;
            _vectorAnimator = new VectorAnimator(localScale, localScale * (1 + _scaleFactor),
                _animationFrameCount, new UnityAnimationCurveAdapter(_animationCurve));
        }

        protected virtual void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            _vectorAnimator.Update();
            transform.localScale = _vectorAnimator.get();
        }

        public void OnHoverEnter()
        {
            if (_vectorAnimator.AnimationState == AnimationState.Animating)
            {
                transform.localScale = _vectorAnimator.Start;
            }

            // it's a little yoda typing, but I think it's alright.
            _vectorAnimator.Behavior = AnimationBehavior.AdvancingForwards;
        }

        public void OnHoverLeave()
        {
            if (_vectorAnimator.Behavior == AnimationBehavior.AdvancingForwards)
            {
                _vectorAnimator.Behavior = AnimationBehavior.AdvancingBackwards;
            }
        }

    }
}