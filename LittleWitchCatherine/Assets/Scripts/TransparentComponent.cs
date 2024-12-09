using UnityEngine;

public class TransparentComponent : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRendArray;

    public void SetSemiTransparent()
    {
        for (int i = 0; i < spriteRendArray.Length; i++)
        {
            spriteRendArray[i].color = new Color(1f, 1f, 1f, 0.6f);
        }
    }
    public void SetNonTransparent()
    {
        for (int i = 0; i < spriteRendArray.Length; i++)
        {
            spriteRendArray[i].color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
