using System.Collections;
using UnityEngine;

public class TransparentComponent : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRendArray;
    [SerializeField] private float minValue = 0.5f;
    private float currentValue = 1f;

    private const float maxValue = 1f;
    public void SetSemiTransparent()
    {
        //��������� ������ �������, ����� �������� ����� � ��������� �������, ����� ��� ������������� ��������� ���� ������� 
        StopAllCoroutines();
        StartCoroutine(TransporancyIncreasing());
    }
    public void SetNonTransparent()
    {
        StopAllCoroutines();
        StartCoroutine(TransporancyDecreasing());
    }

    private IEnumerator TransporancyDecreasing()
    {
        for (; currentValue < maxValue;)
        {
            currentValue += 0.05f;
            for (int j = 0; j < spriteRendArray.Length; j++)
            {
                spriteRendArray[j].color = new Color(1f, 1f, 1f, currentValue);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    private IEnumerator TransporancyIncreasing()
    {
        //���������� ������������, ��������������� �� ����������� �� � min, �� � max
        for (; currentValue > minValue; currentValue -= 0.05f)
        {
            for (int j = 0; j < spriteRendArray.Length; j++)
            {
                spriteRendArray[j].color = new Color(1f, 1f, 1f, currentValue);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
