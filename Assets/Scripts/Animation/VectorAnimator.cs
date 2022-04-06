
using System;
using UnityEngine;

namespace Animation
{

    
    public class VectorAnimator: FundamentalAnimator<Vector3>
    {
        /// <inheritdoc />
        public VectorAnimator(Vector3 start, Vector3 end, int animationFrames, IAnimationCurve curve) : base(start, end, animationFrames, curve)
        {
        }

        public override Vector3 get()
        {
            return Vector3.Lerp(Start, End, AnimationProgress);
        }
    }

}
