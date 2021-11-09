using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [TextArea(0, 15)]
    public List<string> dialog;

    [SerializeField] GameObject dialogCanvas;
    [SerializeField] TMP_Text mainText;
    [SerializeField] TMP_Text specialText;
    [SerializeField] float textCharDelay;
    float currentTextDelay;
    [SerializeField] float specialTextDelay;
    [SerializeField] float dialogDistanceAboveTrigger;
    [SerializeField] bool stickToPlayer = true;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource textAudioSource;
    [SerializeField] AudioClip specialTextClip;
    [SerializeField] AudioClip textAudioClip;
    [Range(0f, 1f)] [SerializeField] float textClipVolume;
    Queue<string> dialogQueue = new Queue<string>();
    Vector2 stopLocation = Vector2.zero;
    [SerializeField] GlobalBool canMove;
    [SerializeField] GlobalBool actionPressed;
    [SerializeField] GlobalBool canUseAction;

    void Start()
    {
        currentTextDelay = textCharDelay;
        player = GameObject.FindWithTag("Player");
        specialText.enabled = false;
        dialogCanvas.SetActive(false);
        dialogQueue.Clear();
        foreach (string s in dialog)
            dialogQueue.Enqueue(s);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(nameof(StartDialog));
        GetComponent<Collider2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().Sleep();
        canMove.Value = false;
        stopLocation = other.transform.position;
    }

    public void ResetTextSpeed() => currentTextDelay = textCharDelay;

    void Update()
    {
        if (stickToPlayer && player != null)
            dialogCanvas.transform.position = player.transform.position + Vector3.up * dialogDistanceAboveTrigger;
        if (actionPressed.Value && dialogQueue.Count > 0)
        {
            actionPressed.Value = false;
            StartCoroutine(nameof(StartDialog));
        }
        else if (actionPressed.Value && dialogQueue.Count == 0)
        {
            actionPressed.Value = false;
            mainText.text = "";
            dialogCanvas.SetActive(false);
            canMove.Value = true;
            player.GetComponent<Rigidbody2D>().WakeUp();
        }
    }

    IEnumerator StartDialog()
    {
        specialText.enabled = false;
        if (dialogQueue.Count > 0)
        {
            if (!stickToPlayer)
                dialogCanvas.transform.position = transform.position + Vector3.up * dialogDistanceAboveTrigger;
            dialogCanvas.SetActive(true);
            mainText.text = "";
            canUseAction.Value = false;
            char[] firstDialogSequence = dialogQueue.Dequeue().ToCharArray();
            foreach (char c in firstDialogSequence)
            {
                mainText.text += c;
                textAudioSource.volume = textClipVolume;
                textAudioSource.PlayOneShot(textAudioClip);
                yield return new WaitForSeconds(currentTextDelay);
            }
            yield return new WaitForSeconds(specialTextDelay);
            canUseAction.Value = true;
            specialText.enabled = true;
            textAudioSource.PlayOneShot(specialTextClip);
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}