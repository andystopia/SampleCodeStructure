using System;
using UnityEngine;

namespace Animation
{
    public class LinearAnimationCurve : IAnimationCurve
    {
        public float Evaluate(float value)
        {
            return value;
        }
    }

    public class CustomAnimationCurve : IAnimationCurve
    {
        private readonly Func<float, float> _function;

        public CustomAnimationCurve(Func<float, float> func)
        {
            _function = func;
        }


        public float Evaluate(float value)
        {
            return _function(value);
        }
    }

    public class UnityAnimationCurveAdapter : IAnimationCurve
    {
        private AnimationCurve _curve;

        public UnityAnimationCurveAdapter(AnimationCurve curve)
        {
            _curve = curve;
        }


        public float Evaluate(float value)
        {
            return _curve.Evaluate(value);
        }
    }

}