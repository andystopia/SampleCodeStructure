using ElementHoverComponents;
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                MoveToPreviousElement();
            }
            else
            {
                MoveToNextElement();
            }
        }


        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveToPreviousElement();
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveToNextElement();
        }

        if (Input.GetKeyDown(KeyCode.Return))
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