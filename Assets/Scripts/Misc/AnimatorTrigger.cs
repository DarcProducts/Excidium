using UnityEngine;

public class AnimatorTrigger: MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string triggerName;
    SpriteRenderer sRend;

    void Awake() => sRend = GetComponent<SpriteRenderer>();

    public void Trigger(bool flip)
    {
        animator.SetTrigger(triggerName);
        if (sRend != null)
            sRend.flipX = flip;
    }
}
