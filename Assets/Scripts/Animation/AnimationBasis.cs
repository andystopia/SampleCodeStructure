
using UnityEngine.PlayerLoop;

namespace Animation
{
    public interface IAnimationBasis
    {
        /**
     * Should be a value with 0 at
     * the beginning and 1 at the end
     * of the animation.
     */
        public float AnimationProgress
        {
            get;
        }

        /**
         * Advances the animation
         * by one step.
         */
        public abstract void Update();
        /**
         * Resets the animation to
         * before the first update call.
         */
        public abstract void Reset();

        public abstract bool isFinished();
    }

    public interface IReversibleAnimationBasis : IAnimationBasis
    {
        public abstract void Reverse();
    }

    public class FrameBasedAnimation : IReversibleAnimationBasis
    {
        private int _maxAnimationFrame;
        private int _currentAnimationFrame;


        public float AnimationProgress => (float) _currentAnimationFrame / _maxAnimationFrame;

        private void UpdateAnimationState()
        {
            if (_currentAnimationFrame < _maxAnimationFrame)
            {
                _currentAnimationFrame++;
            }
        }
        public void Update()
        {
            UpdateAnimationState();
        }

        public void Reset()
        {
            _currentAnimationFrame = 0;
        }

        public void Reverse()
        {
            _maxAnimationFrame = _currentAnimationFrame;
            _currentAnimationFrame = 0;
        }

        public bool isFinished()
        {
            return _currentAnimationFrame == _maxAnimationFrame;
        }
    }
}