using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransparencyChangerComponent : MonoBehaviour, IFadeable
{
    [SerializeField] private float minValue = 0.5f;
    [SerializeField] private float stepValue = 0.05f;
    [SerializeField] private float stepTime = 0.05f;
    [SerializeField] private SpriteRenderer[] spriteRendArray;

    private float currentValue = 1f;

    private const float maxValue = 1f;

    public void FadeOut()
    {
        //остановка других корутин, чтобы избежать багов с мерцанием спрайта, багов при одновременном включении двух корутин 
        StopAllCoroutines();
        StartCoroutine(FadeOutProcces());
    }
    public void UnFade()
    {
        StopAllCoroutines();
        StartCoroutine(UnFadeProcces());
    }
    private IEnumerator UnFadeProcces()
    {
        for (; currentValue < maxValue;)
        {
            currentValue += stepValue;
            for (int j = 0; j < spriteRendArray.Length; j++)
            {
                spriteRendArray[j].color = new Color(1f, 1f, 1f, currentValue);
            }
            yield return new WaitForSeconds(stepTime);
        }
    }
    private IEnumerator FadeOutProcces()
    {
        //”величение прозрачности, текущее«начение не хардкодитс€ ни к min, ни к max
        for (; currentValue > minValue; currentValue -= stepValue)
        {
            for (int j = 0; j < spriteRendArray.Length; j++)
            {
                spriteRendArray[j].color = new Color(1f, 1f, 1f, currentValue);
            }
            yield return new WaitForSeconds(stepTime);
        }
    }    
}
