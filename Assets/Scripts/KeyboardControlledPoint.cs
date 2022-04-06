using KeyboardUtils;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeyboardControlledPoint : MonoBehaviour
    {
        [SerializeField] private KeyCode _moveUp;
        [SerializeField] private KeyCode _moveDown;
        [SerializeField] private KeyCode _moveLeft;
        [SerializeField] private KeyCode _moveRight;

        [SerializeField] private float _movementSpeed = 1;

        private RepeatingKey _upKey;
        private RepeatingKey _downKey;
        private RepeatingKey _leftKey;
        private RepeatingKey _rightKey;

        protected virtual void Awake()
        {
            int numerator = 2;
            int initialDelay = 6;
            _upKey = new RepeatingKey(new InverseFunctionWithInitialDelay(numerator, initialDelay), _moveUp);
            _downKey = new RepeatingKey(new InverseFunctionWithInitialDelay(numerator, initialDelay), _moveDown);
            _leftKey = new RepeatingKey(new InverseFunctionWithInitialDelay(numerator, initialDelay), _moveLeft);
            _rightKey = new RepeatingKey(new InverseFunctionWithInitialDelay(numerator, initialDelay), _moveRight);
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