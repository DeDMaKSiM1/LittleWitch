using System;
using UnityEngine;

public class TransparentTriggerComponent : MonoBehaviour
{
    private TransparentComponent transparentComponent;

    private void Start()
    {
        transparentComponent = FindFirstObjectByType<TransparentComponent>();
    }
    public void ToLaunchTrigger()
    {
    }
}
