using UnityEngine;
using UnityEngine.Events;

public class ClickTrigger : MonoBehaviour
{
    public UnityEvent OnClick;
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    private void OnMouseDown()
    {
        OnClick.Invoke();
    }
    private void OnMouseExit()
    {
        OnExit.Invoke();
    }
    private void OnMouseEnter()
    {
        OnEnter.Invoke();
    }
}
