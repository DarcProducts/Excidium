using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNextArea : MonoBehaviour
{
    [SerializeField] GameObject areaToTurnOff;
    [SerializeField] GameObject areaToTurnOn;
    [SerializeField] Transform nextLocation;
    [SerializeField] GlobalVector2 spawnLocation;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            areaToTurnOn.SetActive(true);
            spawnLocation.Value = nextLocation.position;
            GameManager.S.SpawnPlayer(0);
            DialogManager.S.ClearDialog();
            areaToTurnOff.SetActive(false);
        }
    }
}
