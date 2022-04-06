using UnityEngine;

namespace ElementClickComponents
{
    public class ClickPrintHandler : MonoBehaviour, IClickHandler
    {
        [SerializeField] private string message;


        public void clicked() => print(message);
        
    }
}