using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    void Start() => Destroy(gameObject, timeToDestroy);
}
