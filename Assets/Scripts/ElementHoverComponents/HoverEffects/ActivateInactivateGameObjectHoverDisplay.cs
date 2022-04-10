using UnityEngine;

namespace ElementHoverComponents.HoverEffects
{
    public class ActivateInactivateGameObjectHoverDisplay : MonoBehaviour, IHoverBehaviour
    {
        [SerializeField] private GameObject _targetGameObject;


        protected virtual void Awake()
        {
            if (_targetGameObject != null) _targetGameObject.SetActive(false);
        }
        
        public void OnHoverEnter()
        {
            if (_targetGameObject != null) _targetGameObject.SetActive(true);
        }

        public void OnHoverLeave()
        {
            if (_targetGameObject != null) _targetGameObject.SetActive(false);
        }
    }
}