using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    [SerializeField] GlobalFloat musicVolume;
    [SerializeField] AudioSource musicSource;

    void OnEnable() => musicVolume.OnValueChanged += UpdateBackgroundMusicVolume;

    void OnDisable() => musicVolume.OnValueChanged -= UpdateBackgroundMusicVolume;

    public void UpdateBackgroundMusicVolume(float newValue) => musicSource.volume = newValue;
}
