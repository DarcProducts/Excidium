using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAudio : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] Vector2 pitch;
    public static float DialogVolume;

    public void PlayDialogAudio() => StartCoroutine(nameof(PDA));

    IEnumerator<WaitForSeconds> PDA()
    {
        source.volume = DialogVolume;
        source.pitch = UnityEngine.Random.Range(pitch.x, pitch.y);
        source.Play();
        yield return new WaitForSeconds(clip.length);
    }

    public static void IncreaseVolume() => DialogAudio.DialogVolume += .1f;
    public static void DecreaseVolume() => DialogAudio.DialogVolume -= .1f;
}
