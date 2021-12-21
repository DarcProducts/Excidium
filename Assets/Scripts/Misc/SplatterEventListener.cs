using UnityEngine;

public class SplatterEventListener : MonoBehaviour
{
    [SerializeField] AudioTrigger splatterFX;
    [SerializeField] AudioSource splatterSource;

    void OnEnable() => Acid.Splatter += PlaySplatterSound;

    void OnDisable() => Acid.Splatter -= PlaySplatterSound;

    void PlaySplatterSound()
    {
        if (splatterFX != null && splatterSource != null)
            splatterFX.Trigger(splatterSource);
    }
}
