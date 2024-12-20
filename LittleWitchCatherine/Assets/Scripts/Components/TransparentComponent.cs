using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransparentComponent : MonoBehaviour
{
    [SerializeField] private float minValue = 0.5f;
    [SerializeField] private float stepValue = 0.05f;
    [SerializeField] private float stepTime = 0.05f;
    [SerializeField] private SpriteRenderer[] spriteRendArray;

    private float currentValue = 1f;

    private const float maxValue = 1f;

    public void SetTransparent()
    {
        //��������� ������ �������, ����� �������� ����� � ��������� �������, ����� ��� ������������� ��������� ���� ������� 
        StopAllCoroutines();
        StartCoroutine(ToTransparent());
    }
    public void SetOpaque()
    {
        StopAllCoroutines();
        StartCoroutine(ToOpaque());
    }


    private IEnumerator ToOpaque()
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
    private IEnumerator ToTransparent()
    {
        //���������� ������������, ��������������� �� ����������� �� � min, �� � max
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
