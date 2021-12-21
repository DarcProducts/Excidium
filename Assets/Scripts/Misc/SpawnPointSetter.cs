using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSetter : MonoBehaviour
{
    [SerializeField] GlobalVector2 spawnPoint;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
           spawnPoint.Value = transform.position; 
    }
}
