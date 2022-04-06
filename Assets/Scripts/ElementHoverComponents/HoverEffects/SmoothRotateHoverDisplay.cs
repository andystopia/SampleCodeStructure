using Animation;
using UnityEngine;
using AnimationState = Animation.AnimationState;

namespace ElementHoverComponents.HoverEffects
{
    public class SmoothRotateHoverDisplay : MonoBehaviour, IHoverBehaviour
    {
        [SerializeField] private float _rotationDegrees = 15;
        [SerializeField] private int _animationFrameCount = 10;
        [SerializeField] private AnimationCurve _animationCurve;

        private FundamentalAnimator<Quaternion> _animator;
    
        private Vector3 _startingScale;

        protected virtual void Awake()
        {
            _animator = new QuaternionAnimator(transform.localRotation, Quaternion.AngleAxis(_rotationDegrees, Vector3.forward),
                _animationFrameCount, new UnityAnimationCurveAdapter(_animationCurve));
        }

        protected virtual void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            _animator.Update();
            transform.localRotation = _animator.get();
        }

        public void OnHoverEnter()
        {
            if (_animator.AnimationState == AnimationState.Animating)
            {
                transform.localRotation = _animator.Start;
            }

            // it's a little yoda typing, but I think it's alright.
            _animator.Behavior = AnimationBehavior.AdvancingForwards;
        }

        public void OnHoverLeave()
        {
            _animator.Behavior = AnimationBehavior.AdvancingBackwards; 
        }

    }
}