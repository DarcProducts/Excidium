using UnityEngine;

public class EyeBlinker : MonoBehaviour
{
    [SerializeField] Animator leftEyeAnimator, rightEyeAnimator;
    [SerializeField] string triggerName;
    [Range(0f, 1f)] [SerializeField] float chanceToBlink; 
    [SerializeField] GlobalBool[] blinkEyes;

    void OnEnable() {
        foreach (var b in blinkEyes)
            b.OnValueChanged += Blink;
    }

    void OnDisable() {
        foreach (var b in blinkEyes)
            b.OnValueChanged -= Blink;
    }

    public void Blink(bool isTrue)
    {
        float val = Random.value;
        if (val > chanceToBlink) return;
        if (isTrue)
        {

            leftEyeAnimator.SetTrigger(triggerName);
            rightEyeAnimator.SetTrigger(triggerName);
        }
    }
}
