using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNextArea : MonoBehaviour
{
    [SerializeField] GameObject areaToTurnOff;
    [SerializeField] GameObject areaToTurnOn;
    [SerializeField] Transform nextLocation;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            areaToTurnOn.SetActive(true);
            other.transform.position = nextLocation.position;
            areaToTurnOff.SetActive(false);
            DialogManager.S.ClearDialog();
        }
    }
}
