using UnityEngine;

public class TransparentEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SemiTransparent"))
        {
            var transparent = collision.GetComponent<FadeOnPlayerEnter>();
            transparent.FadeOut();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SemiTransparent"))
        {
            var transparent = collision.GetComponent<FadeOnPlayerEnter>();
            transparent.UnFade();
        }
    }

}
