using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Slider fXSlider;
    [SerializeField] GlobalFloat fXVolume;
    [SerializeField] Slider dialogSlider;
    [SerializeField] GlobalFloat dialogVolume;
    [SerializeField] Slider musicSlider;
    [SerializeField] GlobalFloat musicVolume;
    [SerializeField] Dialog testDialog;
    [SerializeField] AudioSource testSource;

    void OnEnable()
    {
        fXVolume.OnValueChanged += UpdateFXVolume;
        dialogVolume.OnValueChanged += UpdateDialogVolume;
        musicVolume.OnValueChanged += UpdateMusicVolume;
    }

    void OnDisable()
    {
        fXVolume.OnValueChanged -= UpdateFXVolume;
        dialogVolume.OnValueChanged -= UpdateDialogVolume;
        musicVolume.OnValueChanged -= UpdateMusicVolume;
    }

    public void UpdateFXVolume(float value) => fXSlider.value = value;

    public void UpdateFXVolume() => fXVolume.Value = fXSlider.value;

    public void UpdateDialogVolume()
    {
        dialogVolume.Value = dialogSlider.value;
        testDialog.volumeControl = dialogSlider.value;
        if (testDialog != null && testSource != null)
            testDialog.TriggerAudio(testSource);
    }

    public void UpdateDialogVolume(float value)
    {
        dialogSlider.value = value;
    }

    public void UpdateMusicVolume(float value) => musicSlider.value = value;
    
    public void UpdateMusicVolume() => musicVolume.Value = musicSlider.value;
}
