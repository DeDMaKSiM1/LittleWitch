using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransparentComponent : MonoBehaviour
{
    [SerializeField] private float minValue = 0.5f;
    [SerializeField] private float stepValue = 0.05f;
    [SerializeField] private float stepTime = 0.05f;
    [SerializeField] private float pauseTime = 0.5f;
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

    public void SetCycleToOpaqueAndBack()
    {
        StopAllCoroutines();
        StartCoroutine(FromTransparentToOpaqueAndBack());
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
    private IEnumerator FromTransparentToOpaqueAndBack()
    {
        float value = 0;
        //���������� ������������
        //����� +stepValue ������ ��� ��� �����. ��������� ��������� ����������� � ��-�� ��� �� ����������� ����������(0 � 1) ��������� ������������
        for (; value < maxValue + stepValue; value += stepValue)
        {
            Debug.Log(value);
            for (int j = 0; j < spriteRendArray.Length; j++)
            {
                spriteRendArray[j].color = new Color(spriteRendArray[j].color.r, spriteRendArray[j].color.g, spriteRendArray[j].color.b, value);
            }
            yield return new WaitForSeconds(stepTime);
        }
        //�����
        yield return new WaitForSeconds(pauseTime);
        //���������� ������������ 
        for (; value >= minValue - stepValue; value -= stepValue)
        {
            Debug.Log(value);

            for (int j = 0; j < spriteRendArray.Length; j++)
            {
                spriteRendArray[j].color = new Color(spriteRendArray[j].color.r, spriteRendArray[j].color.g, spriteRendArray[j].color.b, value);
            }
            yield return new WaitForSeconds(stepTime);
        }

    }
}
