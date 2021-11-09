using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] Vector3 cameraOffset;
    float cameraZPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraZPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(targetTransform.position.x, targetTransform.position.y, cameraZPos) + cameraOffset;
        transform.position = newPos;
    }
}
