using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow S;
    [SerializeField] Transform targetTransform;
    [SerializeField] Vector3 cameraOffset;
    float cameraZPos;
    // Start is called before the first frame update

    void Awake() => S = this;

    void Start()
    {
        cameraZPos = transform.position.z;
    }

    public void NullTarget() => targetTransform = null;

    public void SetTarget(Transform target) => targetTransform = target;

    // Update is called once per frame
    void Update()
    {
        if (targetTransform != null)
        {
            Vector3 newPos = new Vector3(targetTransform.position.x, targetTransform.position.y, cameraZPos) + cameraOffset;
            transform.position = newPos;
        }
    }
}
