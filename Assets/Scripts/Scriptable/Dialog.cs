using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Dialog/New Dialog"))]
public class Dialog : ScriptableObject
{
    public string dialog;
    public float displayLength = 1.5f;
    public bool hasBeenRead = false;
    public AudioClip clip = null;
    public Vector2 volume = Vector2.one;
    public Vector2 pitch = Vector2.one;
    public bool checkIfPlaying = false;

    private void OnDisable()
    {
        checkIfPlaying = false;
    }

    public void TriggerAudio(AudioSource source)
    {
        source.volume = Random.Range(Mathf.Min(volume.x, volume.y), Mathf.Max(volume.x, volume.y));
        source.pitch = Random.Range(Mathf.Min(pitch.x, pitch.y), Mathf.Max(pitch.x, pitch.y));
        if (checkIfPlaying)
        {
            if (!source.isPlaying)
                source.PlayOneShot(clip);
        }
        else
            source.PlayOneShot(clip);
    }

    public void TriggerDialog()
    {
        DialogManager.S.AddMessage(this);
        hasBeenRead = true;
    }
}
