
using UnityEngine;
using UnityEngine.Events;

namespace VideoJames.Scriptables.Examples
{
    public class MouseListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent onLeftMouseClicked;
        [SerializeField] private UnityEvent onRightMouseClicked;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
                onLeftMouseClicked.Invoke();
            if(Input.GetMouseButtonDown(1))
                onRightMouseClicked.Invoke();
        }
    } 

}

