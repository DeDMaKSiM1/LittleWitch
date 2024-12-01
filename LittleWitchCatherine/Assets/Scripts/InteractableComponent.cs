using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour
{
    public UnityEvent interactEvent;

    public void InteractEventLaunch()
    {
        interactEvent.Invoke();
    }
}
