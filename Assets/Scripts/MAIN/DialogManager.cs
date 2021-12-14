using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager S;
    [SerializeField] GameObject dialogGameObject;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] float messageTime;
    bool hasStarted = false;
    float _currentTime;
    [SerializeField] Queue<Dialog> dialogQueue = new Queue<Dialog>();
    [SerializeField] AudioSource dialogAudioSource;

    void Awake() => S = this;

    void Start() => dialogGameObject.SetActive(false);

    void Update()
    {
        if (!hasStarted && dialogQueue.Count > 0)
            StartCoroutine(nameof(DisplayMessage));
    }

    void ShowDialogBox() => dialogGameObject.SetActive(true);

    void HideDialogBox() => dialogGameObject.SetActive(false);

    public void AddMessage(Dialog message) => dialogQueue.Enqueue(message);

    public void ClearDialog() => dialogQueue.Clear();

    IEnumerator DisplayMessage()
    {
        hasStarted = true;
        ShowDialogBox();
        Dialog message = dialogQueue.Dequeue();
        AudioClip clip = message.clip;
        dialogText.text = message.dialog;
        if (clip != null)
        {
            message.TriggerAudio(dialogAudioSource);
            yield return new WaitForSeconds(message.clip.length);
        }
        else
            yield return new WaitForSeconds(messageTime);
        HideDialogBox();
        hasStarted = false;
    }
}
