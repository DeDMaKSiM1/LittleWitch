using System.Collections;
using UnityEngine;

public class TransparentComponent : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRendArray;

    private bool IsPlayerExit;
    private bool IsRoutineWorking;
    private const float maxValue = 1f;
    private const float minValue = 0.5f;
    public void SetSemiTransparent()
    {
        if (!IsRoutineWorking)
            StartCoroutine(TransporancyIncreasing());

    }
    public void SetNonTransparent()
    {
        if (!IsRoutineWorking)
            StartCoroutine(TransporancyDecreasing());
    }

    private IEnumerator TransporancyDecreasing()
    {
        IsRoutineWorking = true;
        for (float i = minValue; i <= maxValue;)
        {
            i += 0.05f;
            for (int j = 0; j < spriteRendArray.Length; j++)
            {
                spriteRendArray[j].color = new Color(1f, 1f, 1f, i);
            }
            yield return new WaitForSeconds(0.05f);
        }
        if (IsPlayerExit)
            SetNonTransparent();
        else
            IsRoutineWorking = false;
        Debug.Log($"IsRoutineWorking = {IsRoutineWorking}");
        Debug.Log($"IsPlayerExit = {IsPlayerExit}");
    }
    private IEnumerator TransporancyIncreasing()
    {
        IsRoutineWorking = true;
        for (float i = maxValue; i > minValue; i -= 0.05f)
        {
            for (int j = 0; j < spriteRendArray.Length; j++)
            {
                spriteRendArray[j].color = new Color(1f, 1f, 1f, i);
            }
            yield return new WaitForSeconds(0.05f);
        }
        IsRoutineWorking = false;
        IsPlayerExit = false;
        Debug.Log($"IsRoutineWorking = {IsRoutineWorking}");
        Debug.Log($"IsPlayerExit = {IsPlayerExit}");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerExit = true;
        }
    }
}
