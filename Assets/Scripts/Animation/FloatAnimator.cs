using System;
using UnityEngine;

namespace Animation
{
    public class FloatAnimator : FundamentalAnimator<float>
    {
        public FloatAnimator(float start, float end, int animationFrames, IAnimationCurve curve) : base(start, end, animationFrames, curve)
        {
        }

        public override float get()
        {
            return Mathf.Lerp(Start, End, AnimationProgress);
        }
    }
}