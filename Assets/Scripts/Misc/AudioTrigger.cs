using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] Vector2 minMaxVolume;
    [SerializeField] Vector2 minMaxPitch;
    [SerializeField] bool checkIfPlaying = false;

    public void Trigger()
    {
        source.volume = Random.Range(minMaxVolume.x, minMaxVolume.y);
        source.pitch = Random.Range(minMaxPitch.x, minMaxPitch.y);
        if (checkIfPlaying)
        {
            if (!source.isPlaying)
                source.PlayOneShot(clip);
        }
        else
            source.PlayOneShot(clip);
    }
}