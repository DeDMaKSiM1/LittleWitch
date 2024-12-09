using UnityEngine;

public class TransparentCheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SemiTransparent"))
        {
            var transparent = collision.GetComponent<TransparentComponent>();
            transparent.SetSemiTransparent();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SemiTransparent"))
        {
            var transparent = collision.GetComponent<TransparentComponent>();
            transparent.SetNonTransparent();
        }
    }
}
