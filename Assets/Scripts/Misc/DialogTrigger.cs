using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            if (!dialog.hasBeenRead)
            {
                dialog.hasBeenRead = true;
                dialog.AddDialogToQueue();
            }
    }
}