using UnityEngine;

public class EnteredNewArea : MonoBehaviour
{
    public Area areaName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!areaName.hasBeenSeen)
            {
                AreaEnteredController.S.ShowAreaEntered(areaName.newAreaName);
                areaName.hasBeenSeen = true;
            }
        }
    }
}
