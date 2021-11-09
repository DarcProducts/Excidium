using UnityEngine;

public class RandomizeRotate : MonoBehaviour
{
    [SerializeField] Vector3 rotateVector;

    void OnEnable() => transform.rotation *= Quaternion.Euler(rotateVector.normalized * Random.Range(-180f, 180f));
}