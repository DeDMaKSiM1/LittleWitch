using System;
using UnityEngine;

public class TransparentTriggerComponent : MonoBehaviour
{
    protected Animator animator;

    protected const string TransitionTrigger = "TransitionCycle";
    protected void Awake()
    {
        var overlappingImage = GameObject.Find("TransitionManager");
        animator = overlappingImage.GetComponent<Animator>();
    }
    public void ToLaunchTrigger()
    {
        animator.SetTrigger(TransitionTrigger);
    }
}
