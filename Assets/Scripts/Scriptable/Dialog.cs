using UnityEngine;

[CreateAssetMenu(menuName = ("Dialog/New Dialog"))]
public class Dialog : ScriptableObject
{
    public string dialog;
    public float displayLength = 1.5f;
    public AudioClip dialogClip = null;
    public Vector2 pitch = Vector2.one;
    [HideInInspector]
    public float volumeControl = 1;
    public bool hasBeenRead;

    public float TriggerAudio(AudioSource source)
    {
        source.Stop();
        source.volume = volumeControl;
        source.pitch = Random.Range(Mathf.Min(pitch.x, pitch.y), Mathf.Max(pitch.x, pitch.y));      
        source.clip = dialogClip;
        source.Play();
        return dialogClip.length;
    }

    public void AddDialogToQueue() => DialogManager.S.AddMessage(this);
}
