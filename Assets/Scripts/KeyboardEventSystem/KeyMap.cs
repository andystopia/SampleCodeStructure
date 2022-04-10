using UnityEngine;
using Debug = UnityEngine.Debug;

namespace KeyboardEventSystem
{
    /**
 * This class manages what key mapping is active.
 *
 * Using the ActiveMap property of this class
 * will allow assignment and reassignment of this
 * class.
 *
 * Note that while this class is a MonoBehehavior,
 * it will work without ever being added to the scene.
 *
 * You only want to add it to an object if you want
 * to be able to set the default keymap from the
 * editor, in which case, this object only needs
 * to exist and be active, and it will preserve
 * its state even if the entity dies.
 *
 *
 * Note that since it's fundamentally pretty
 * cheap to pass references around, perhaps
 * consider taking this class by pointer, instead
 * of passing through the active map or passing
 * through the keycode itself. This choice
 * will allow for hot swapping key maps later.
 */
    public class KeyMap : MonoBehaviour
    {
        [SerializeField]
        private KeyMapping editorAssignedKeyMapping;

        // store the instance if you need to.
        private static KeyMap instance;

        /// <summary>
        /// The active key key mapping.
        ///
        /// Determines which keys correspond to which
        /// actions in the game. 
        /// </summary>
        public static KeyMapping ActiveMap { get; set; }

        private void Awake()
        {
        
            if (instance == null)
            {
                instance = this;
                ActiveMap = editorAssignedKeyMapping;
            }
            else
            {
                Debug.Log($"You should never have more than one ${nameof(KeyMap)} instance active");
            }
        }
    }
}