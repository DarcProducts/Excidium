using UnityEngine;

public class AnimatorTrigger: MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string triggerName;

    public void Trigger() => animator.SetTrigger(triggerName);
}
