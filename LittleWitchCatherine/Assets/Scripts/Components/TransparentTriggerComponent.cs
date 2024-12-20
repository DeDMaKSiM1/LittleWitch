using System;
using UnityEngine;

public class TransparentTriggerComponent : MonoBehaviour
{
    private Animator animator;

    private const string TransitionTrigger = "TransitionCycle";
    private void Start()
    {
        var overlappingImage = GameObject.Find("TransitionManager");
        animator = overlappingImage.GetComponent<Animator>();
    }
    public void ToLaunchTrigger()
    {
        animator.SetTrigger(TransitionTrigger);
    }
}
