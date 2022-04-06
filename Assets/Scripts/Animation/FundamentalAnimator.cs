using System;

namespace Animation
{
    public abstract class FundamentalAnimator<T>
    {
        protected T _start;
        protected T _end;
        private readonly IAnimationBasis _animationFormat;
        private readonly IAnimationCurve _curve;

        
        public T Start => _start;
        public T End => _end;

        private int _currentFrame = 0;
        private int _endingFrame = 0;

        public float AnimationProgress => (float) _currentFrame / _endingFrame;

        /**
         * Determines the active animation direction
         * of this animation. Note that setting this
         * to the reverse direction does reset the
         * zeroth frame to the opposite endpoint,
         * it does the reverse of what the forward
         * direction does. The EndVector is always
         * in the direction of the forwards animation.
         */
        public AnimationBehavior Behavior { get; set; }
        /**
         * Returns the current state of the animation.
         *
         * Note that animations heading in reverse
         * are considered finished when the current
         * frame is at zero.
         *
         * Animations that are heading forwards
         * are considered finished when they
         * have elapsed a certain number of frames.
         */
        public AnimationState AnimationState {
            get
            {
                if (Behavior == AnimationBehavior.AdvancingForwards && _currentFrame == _endingFrame)
                {
                    return AnimationState.Finished;
                }

                if (Behavior == AnimationBehavior.AdvancingBackwards && _currentFrame == 0)
                {
                    return AnimationState.Finished;
                }

                return AnimationState.Animating;
            }
        }


        
        /// <summary>
        /// Instantiates a new  Animator (frame-based)
        ///
        /// Note that the default Behavior is "Paused" which
        /// means that calls to update will not effect calls
        /// to get in any way.
        ///
        /// If you want the animation to progress forwards
        /// set the behavior to be advancing forwards.
        /// </summary>
        /// <param name="start">the place to start at</param>
        /// <param name="end"> the place to end with </param>
        /// <param name="animationFrames">the number of frames this animation should take</param>
        /// <param name="curve">the curve to use for this animation.</param>
        public FundamentalAnimator(T start, T end, int animationFrames, IAnimationCurve curve)
        {
            _start = start;
            _end = end;
            _endingFrame = animationFrames;
            _curve = curve;
            Behavior = AnimationBehavior.Paused;
        }

        public abstract T get();

        public void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            switch (Behavior)
            {
                case AnimationBehavior.AdvancingForwards:
                    if (_currentFrame < _endingFrame)
                    {
                        _currentFrame++;
                    }

                    break;
                case AnimationBehavior.AdvancingBackwards:
                    if (_currentFrame > 0)
                    {
                        _currentFrame--;
                    }

                    break;
                case AnimationBehavior.Paused:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    
    public enum AnimationBehavior
    {
        AdvancingForwards,
        AdvancingBackwards,
        Paused,
    }

    public enum AnimationState
    {
        Animating,
        Finished,
    }
}