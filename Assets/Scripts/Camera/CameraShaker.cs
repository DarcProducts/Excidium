using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShaker : MonoBehaviour
{
    public static CameraShaker S = null;
    float currentTime;
    float currentMagnitude;
    Vector3 cameraOriginalPos;
    Vector3 newFactor = Vector3.zero;
    bool shakeCamera;
    bool hasPosition = false;


    void Awake() => S = this;

    void OnEnable()
    {
        currentTime = currentMagnitude;
        cameraOriginalPos = transform.localPosition;
    }

    void FixedUpdate()
    {
        currentTime = currentTime < 0 ? 0 : currentTime -= Time.fixedDeltaTime;
        if (currentTime > 0 && shakeCamera)
        {
            newFactor = cameraOriginalPos + (Vector3)Random.insideUnitCircle * currentMagnitude;
            transform.localPosition = newFactor;
            transform.rotation = transform.rotation *= Quaternion.Euler(newFactor * currentMagnitude);
        }
    }

    [ContextMenu("Trigger Camera Shake")]
    public void Trigger(float magnitude) 
    {
        float clampedMag = Mathf.Clamp01(magnitude);
        currentMagnitude = clampedMag;
        StartCoroutine(ShakeCamera(clampedMag));
    }

    IEnumerator ShakeCamera(float magnitude)
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