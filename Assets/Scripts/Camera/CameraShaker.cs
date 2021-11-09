using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShaker : MonoBehaviour
{
    public static CameraShaker S = null;
    [Range(0f, 1f)] [SerializeField] float magnitude;
    float currentTime;
    Vector3 cameraOriginalPos;
    Vector3 newFactor = Vector3.zero;
    bool shakeCamera;
    bool hasPosition = false;


    void Awake() => S = this;

    void OnEnable()
    {
        currentTime = magnitude * 2;
        cameraOriginalPos = transform.localPosition;
    }

    void FixedUpdate()
    {
        currentTime = currentTime < 0 ? 0 : currentTime -= Time.fixedDeltaTime;
        if (currentTime > 0 && shakeCamera)
        {
            newFactor = cameraOriginalPos + (Vector3)Random.insideUnitCircle * magnitude;
            transform.localPosition = newFactor;
            transform.rotation = transform.rotation *= Quaternion.Euler(newFactor * magnitude);
        }
    }

    [ContextMenu("Trigger Camera Shake")]
    public void Trigger() => StartCoroutine(ShakeCamera());

    IEnumerator ShakeCamera()
    {
        if (!hasPosition)
        {
            cameraOriginalPos = transform.localPosition;
            hasPosition = true;
        }
        currentTime = magnitude * 2;
        shakeCamera = true;
        yield return new WaitForSeconds(magnitude * 2);
        transform.localPosition = cameraOriginalPos;
        transform.rotation = Quaternion.identity;
        hasPosition = false;
        shakeCamera = false;
    }
}