using ElementHoverComponents;
using KeyboardEventSystem;
using UnityEngine;

public class KeyboardIndexManager : MonoBehaviour
{
    [SerializeField]
    private HoverMediator[] mediators;

    private int? activeMediatorIndex;

    private void MoveToNextElement()
    {
        if (activeMediatorIndex == null)
        {
            if (mediators.Length > 0)
            {
                activeMediatorIndex = 0;
            }
        }
        else
        {
            if (activeMediatorIndex < mediators.Length - 1)
            {
                activeMediatorIndex++;
            }
        }

        if (activeMediatorIndex != null)
        {
            mediators[activeMediatorIndex.Value].HoverEnterRequested();
        }
    }
    
    private void MoveToPreviousElement()
    {
        if (activeMediatorIndex == null)
        {
            if (mediators.Length > 0)
            {
                activeMediatorIndex = 0;
            }
        }
        else
        {
            if (activeMediatorIndex > 0)
            {
                activeMediatorIndex--;
            }
        }

        if (activeMediatorIndex != null)
        {
            mediators[activeMediatorIndex.Value].HoverEnterRequested();
        }
    }
    private void HandleKeyboardInput()
    {
        if (KeyMap.ActiveMap.ForwardThroughList.WasPressedThisFrame())
        {
            MoveToNextElement();
        }

        if (KeyMap.ActiveMap.BackwardThroughListKey.WasPressedThisFrame())
        {
            MoveToPreviousElement();
        }



        if (KeyMap.ActiveMap.KeyboardClickKey.WasPressedThisFrame())
        {
            if (activeMediatorIndex != null)
            {
                HoverMediator mediator = mediators[activeMediatorIndex.Value];
                if (mediator.AssociatedClickMediator != null)
                {
                    mediator.AssociatedClickMediator.RequestClicked();
                }
            }
        }
    }
    
    
    protected virtual void Update()
    {
        HandleKeyboardInput();
    }

}