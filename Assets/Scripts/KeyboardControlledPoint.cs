using KeyboardEventSystem;
using KeyboardUtils;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeyboardControlledPoint : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 1;
        [SerializeField] private int _frameGap = 2;
        private RepeatingKey _upKey;
        private RepeatingKey _downKey;
        private RepeatingKey _leftKey;
        private RepeatingKey _rightKey;

        protected virtual void Awake()
        {
            int numerator = 2;
            int initialDelay = 6;
            _upKey = new RepeatingKey(new InverseFunctionWithInitialDelay(numerator, initialDelay), KeyMap.ActiveMap.DotMoveUp.KeyCode, _frameGap);
            _downKey = new RepeatingKey(new InverseFunctionWithInitialDelay(numerator, initialDelay), KeyMap.ActiveMap.DotMoveDown.KeyCode, _frameGap);
            _leftKey = new RepeatingKey(new InverseFunctionWithInitialDelay(numerator, initialDelay), KeyMap.ActiveMap.DotMoveLeft.KeyCode, _frameGap);
            _rightKey = new RepeatingKey(new InverseFunctionWithInitialDelay(numerator, initialDelay), KeyMap.ActiveMap.DotMoveRight.KeyCode, _frameGap);
        }

        protected virtual void Update()
        {
            
            // update all the keys
            _upKey.Update();
            _downKey.Update();
            _leftKey.Update();
            _rightKey.Update();
            
            
            Vector3 relTranslate = Vector3.zero;
            if (_upKey.IsKeyDownFrame())
            {
                relTranslate += Vector3.up;
            }

            if (_downKey.IsKeyDownFrame())
            {
                relTranslate += Vector3.down;
            }

            if (_leftKey.IsKeyDownFrame())
            {
                relTranslate += Vector3.left;
            }

            if (_rightKey.IsKeyDownFrame())
            {
                relTranslate += Vector3.right;
            }


            this.transform.position += relTranslate * _movementSpeed;
        }
    }
}