using System;
using UnityEngine;

namespace KeyboardUtils
{
    public interface IKeyApproachFunction
    {

        
        /// <summary>
        ///  Determines the number of frames
        /// to wait before the next pulse
        /// is sent from the repeating key. 
        /// This function should be relatively simple.
        /// Given the current iteration step return the
        /// number of frames before the next signal
        /// should be sent.
        /// 
        ///  For correct behavior please uphold the invariant:
        /// As lim currentIterationStep -> ∞: output -> 0
        ///
        /// This should always return a value ≥ 1
        /// </summary>
        /// <param name="currentIterationStep">the current iteration step</param>
        /// <returns>the number of frame to wait until the next pulse should be sent.</returns>
        public int getNumberOfFramesToWait(int currentIterationStep);
    }

    public class InverseFunction : IKeyApproachFunction
    {
        private readonly int _numerator;

        public InverseFunction(int numerator)
        {
            _numerator = numerator;
        }

        public int getNumberOfFramesToWait(int currentIterationStep)
        {
            return _numerator / ( currentIterationStep+ 1);
        }
    }

    public class InverseFunctionWithInitialDelay : IKeyApproachFunction
    {
        private readonly int _numerator;
        private readonly int _initialDelay;

        public InverseFunctionWithInitialDelay(int numerator, int initialDelay)
        {
            _numerator = numerator;
            _initialDelay = initialDelay;
        }

        public int getNumberOfFramesToWait(int currentIterationStep)
        {
            if (currentIterationStep == 0)
            {
                return _initialDelay;
            }

            return _numerator / currentIterationStep;
        }
    }

    public class SimpleDelay : IKeyApproachFunction
    {
        private readonly int _delayFrames;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delayFrames">the number of frames to wait before always repeating.</param>
        public SimpleDelay(int delayFrames)
        {
            _delayFrames = delayFrames;
        }

        /// <summary>
        /// Determines the number of frames
        /// to wait before the next pulse
        /// is sent from the repeating key. 
        /// This function should be relatively simple.
        /// Given the current iteration step return the
        /// number of frames before the next signal
        /// should be sent.
        /// 
        ///  For correct behavior please uphold the invariant:
        /// As lim currentIterationStep -> ∞: output -> 0
        ///
        /// This should always return a value ≥ 1
        /// </summary>
        /// <param name="currentIterationStep">the current iteration step</param>
        /// <returns>the number of frame to wait until the next pulse should be sent.</returns>
        public int getNumberOfFramesToWait(int currentIterationStep)
        {
            if (currentIterationStep == 0) return _delayFrames;
            return 0;
        }
    }
    public class RepeatingKey
    {
        // repeating key needs a few things. 
        // 
        // a) whether or not it should send an initial keystroke
        // b) the asymptotic frame-wise function determining
        // time to register again.
        // c) how many frames should pass before another stroke 
        // sent.

        private int _frameCount = 0;
        private int _waitingFrames = 0;
        private int _iteration = 0;
        private readonly bool _sendInitialKeystroke;
        private readonly int _frameGap;
        private readonly IKeyApproachFunction _approachFunction;
        private readonly KeyCode _keyCode;
        

        /// <summary>
        /// Creates a new repeating key listener instance.
        /// 
        /// </summary>
        /// <param name="approachFunction"></param>
        /// <param name="keyCode"></param>
        /// <param name="frameGap"></param>
        /// <param name="sendInitialKeystroke"></param>
        public RepeatingKey(IKeyApproachFunction approachFunction, KeyCode keyCode, int frameGap = 1,
            bool sendInitialKeystroke=true) 
        {
            _waitingFrames = sendInitialKeystroke ? 0 : getNextWaitTime();
            _approachFunction = approachFunction;
            _keyCode = keyCode;
            _frameGap = frameGap;
            _sendInitialKeystroke = sendInitialKeystroke;
        }

        /// <summary>
        /// Don't forget to call this method.
        ///
        /// It's very important to ensure that everything works correctly.
        /// </summary>
        public void Update()
        {
            if (Input.GetKey(_keyCode))
            {
                _frameCount++;
            }
            else if (Input.GetKeyUp(_keyCode))
            {
                _frameCount = 0;
                _iteration = 0;
            }

            if (Input.GetKeyDown(_keyCode))
            {
                _waitingFrames = _sendInitialKeystroke ? 0 : getNextWaitTime();
            }
        }

        private int getNextWaitTime()
        {
            int framesToWait = _approachFunction.getNumberOfFramesToWait(_iteration) + _frameGap;
            _iteration += 1;
            return framesToWait;
        }
        /// <summary>
        /// Determines whether or not
        /// the key sends the repeat
        /// signal on this frame.
        /// </summary>
        public bool IsKeyDownFrame()
        {
            if (_frameCount < _waitingFrames || !Input.GetKey(_keyCode)) return false;
            
            _waitingFrames = getNextWaitTime();
            _frameCount = 0;
            return true;
        }
    }
}