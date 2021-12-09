using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] DialogString dialog;
    [SerializeField] bool destroyAfterRead = true;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (!dialog.hasBeenRead)
            {
                DialogManager.S.AddMessage(dialog);
                dialog.hasBeenRead = true;
                if (destroyAfterRead)
                    Destroy(gameObject);
            }
        }
    }
}
