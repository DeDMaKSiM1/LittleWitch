using UnityEngine;
using UnityEngine.Events;

public class EnterTrigger : MonoBehaviour
{
    [SerializeField] private string Tag;

    public UnityEvent EnterTriggerEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tag))
            EnterTriggerEvent.Invoke();
    }
}
