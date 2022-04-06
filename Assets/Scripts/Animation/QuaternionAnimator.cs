using UnityEngine;

namespace Animation
{
    public class QuaternionAnimator : FundamentalAnimator<Quaternion>
    {
        /// <inheritdoc />
        public QuaternionAnimator(Quaternion start, Quaternion end, int animationFrames, IAnimationCurve curve) : base(start, end, animationFrames, curve)
        {
        }

        public override Quaternion get()
        {
            return Quaternion.Lerp(Start, End, AnimationProgress);
        }
    }
}