using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Vector3 rotateVector;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.transform.rotation = Quaternion.Euler(new Vector3(rotateVector.x, rotateVector.y, rotateVector.z));
    }
}
