using UnityEngine;

namespace KeyboardEventSystem
{
    /// <summary>
    /// Represents a single key's state.
    /// </summary>
    [System.Serializable]
    public class Key
    {
        [SerializeField]
        private KeyCode keyCode;

        [SerializeField] private bool isShiftHeld;
        [SerializeField] private bool isCtrlHeld;
        [SerializeField] private bool isAltHeld;

        /// <summary>
        /// The Unity KeyCode that this key is based on.
        /// </summary>
        public KeyCode KeyCode => keyCode;

        /// <summary>
        /// Determines if a key is held down.
        /// </summary>
        /// <returns>true if the key is held down, false otherwise</returns>
        public bool IsPressed()
        {
            // Take note that the carrot is the XOR operator.
            return Input.GetKey(KeyCode)
                   && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ^ !isShiftHeld
                   && Input.GetKey(KeyCode.LeftControl) ^ !isCtrlHeld
                   && Input.GetKey(KeyCode.LeftAlt) ^ !isAltHeld;
        }

        /// <summary>
        /// Determines if this key was pressed this frame.
        /// </summary>
        /// <returns>true if the key was released this frame, false otherwise</returns>
        public bool WasPressedThisFrame()
        {
            // Take note that the carrot is the XOR operator.
            return Input.GetKeyDown(KeyCode)
                   && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ^ !isShiftHeld
                   && Input.GetKey(KeyCode.LeftControl) ^ !isCtrlHeld
                   && Input.GetKey(KeyCode.LeftAlt) ^ !isAltHeld;
        }

       
        /// <summary>
        /// Determines if the key was released this frame.
        /// </summary>
        /// <returns>true if the key was released this frame, false otherwise</returns>
        public bool WasReleasedThisFrame()
        {
            // Take note that the ^ operator is XOR 
            return Input.GetKeyUp(KeyCode)
                   && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ^ !isShiftHeld
                   && Input.GetKey(KeyCode.LeftControl) ^ !isCtrlHeld
                   && Input.GetKey(KeyCode.LeftAlt) ^ !isAltHeld;
        }
    }
}