using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.KillPlayer?.Invoke();
        }
    }
}
