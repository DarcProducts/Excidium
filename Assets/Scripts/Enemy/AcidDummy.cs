using System.Collections;
using UnityEngine;

public class AcidDummy : MonoBehaviour
{
    [HideInInspector]
    public Vector2 duration;

    void OnEnable() => StartCoroutine(nameof(DelayedDeactivate));

    void OnDisable() => StopCoroutine(nameof(DelayedDeactivate));

    IEnumerator DelayedDeactivate()
    {
        yield return new WaitForSeconds(Random.Range(duration.x, duration.y));
        gameObject.SetActive(false);
    }
}
