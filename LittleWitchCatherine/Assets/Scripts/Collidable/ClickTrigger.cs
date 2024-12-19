using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ClickTrigger : MonoBehaviour
{
    public UnityEvent OnClick;
    public void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
