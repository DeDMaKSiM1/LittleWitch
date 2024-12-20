using UnityEngine;

public class TransparentTriggerComponentFromOpaque : TransparentTriggerComponent
{
    [SerializeField] private AnimationClip clip;

    public new void ToLaunchTrigger()
    {
        animator.Play(clip.name);
    }
}
