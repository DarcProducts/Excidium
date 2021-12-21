using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager S;
    [SerializeField] private GameObject dialogGameObject;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private float messageTime;
    [SerializeField] GlobalFloat dialogVolume;
    private bool hasStarted = false;
    private float _currentTime;
    [SerializeField] private Queue<Dialog> dialogQueue = new Queue<Dialog>();
    [SerializeField] private AudioSource dialogAudioSource;

    private void Awake() => S = this;

    private void Start() => dialogGameObject.SetActive(false);

    private void Update()
    {
        if (!hasStarted && dialogQueue.Count > 0)
            StartCoroutine(nameof(DisplayMessage));
    }

    private void ShowDialogBox() => dialogGameObject.SetActive(true);

    private void HideDialogBox() => dialogGameObject.SetActive(false);

    public void AddMessage(Dialog message) => dialogQueue.Enqueue(message);

    public void ClearDialog() => dialogQueue.Clear();

    public void StopDialog()
    {
        dialogText.text = "";
        StopCoroutine(nameof(DisplayMessage));
        dialogQueue.Clear();
        dialogAudioSource.Stop();
    }

    private IEnumerator DisplayMessage()
    {
        hasStarted = true;
        ShowDialogBox();
        Dialog message = dialogQueue.Dequeue();
        dialogText.text = message.dialog;
        message.volumeControl = dialogVolume.Value;

        if (message.dialogClip != null)
            yield return new WaitForSeconds(message.TriggerAudio(dialogAudioSource));
        else
            yield return new WaitForSeconds(message.displayLength);

        HideDialogBox();
        hasStarted = false;
    }
}