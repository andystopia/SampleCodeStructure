using System;
using UnityEngine;

namespace ElementClickComponents
{
    [RequireComponent(typeof(ClickMediator))]
    public class MouseButtonClickSource : MonoBehaviour
    {
        private ClickMediator _clickMediator;

        private void Awake()
        {
            _clickMediator = GetComponent<ClickMediator>();
        }
        private void OnMouseDown()
        {
            _clickMediator.RequestClicked();
        }
    }
}