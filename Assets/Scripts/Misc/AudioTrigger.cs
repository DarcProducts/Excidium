using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] Vector2 minMaxVolume;
    [SerializeField] Vector2 minMaxPitch;
    [SerializeField] bool checkIfPlaying = false;
    [SerializeField] GlobalFloat masterVolume;

    public void Trigger(AudioSource source)
    {
        if (masterVolume != null)
            source.volume = Mathf.Clamp01(Random.Range(minMaxVolume.x, minMaxVolume.y) * masterVolume.Value);
        else
            source.volume = Mathf.Clamp01(Random.Range(minMaxVolume.x, minMaxVolume.y));
        source.pitch = Mathf.Clamp(Random.Range(minMaxPitch.x, minMaxPitch.y), -3, 3);
        if (checkIfPlaying)
        {
            if (!source.isPlaying)
                source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
        else
            source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}