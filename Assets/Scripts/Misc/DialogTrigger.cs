using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] Dialog dialog;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            if (!dialog.hasBeenRead)
                dialog.TriggerDialog();
    }
}
