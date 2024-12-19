using UnityEngine;
using UnityEngine.Events;

public class ClickTrigger : MonoBehaviour
{
    public UnityEvent OnClick;
    private void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
