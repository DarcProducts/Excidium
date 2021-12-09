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
    [SerializeField] Queue<DialogString> dialogQueue = new Queue<DialogString>();


    void Awake() => S = this;

    void Start() {
        dialogGameObject.SetActive(false);
    }

    void Update()
    {
        if (!hasStarted && dialogQueue.Count > 0)
            StartCoroutine(nameof(DisplayMessage));
    }

    void ShowDialogBox() => dialogGameObject.SetActive(true);

    void HideDialogBox() => dialogGameObject.SetActive(false);

    public void AddMessage(DialogString message) => dialogQueue.Enqueue(message);


    IEnumerator DisplayMessage()
    {
        hasStarted = true;
        ShowDialogBox();
        DialogString message = dialogQueue.Dequeue();
        dialogText.text = message.dialog;
        yield return new WaitForSeconds(message.displayLength);
        HideDialogBox();
        hasStarted = false;
    }
}
