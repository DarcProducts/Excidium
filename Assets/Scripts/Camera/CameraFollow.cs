using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow S;
    [SerializeField] Transform targetTransform;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float cameraFollowSpeed;
    [SerializeField] float maxDistance;
    float currentSpeed;
    Vector2 startingPos;
    float cameraZPos;
    // Start is called before the first frame update

    void Awake() => S = this;

    void Start()
    {
        currentSpeed = cameraFollowSpeed;
        startingPos = transform.position;
        cameraZPos = transform.position.z;
    }

    public void NullTarget() => targetTransform = null;

    public void SetTarget(Transform target) => targetTransform = target;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            Vector3 currentPos = transform.position;
            Vector3 newPos = new Vector3(targetTransform.position.x, targetTransform.position.y, cameraZPos) + cameraOffset;
            transform.position = Vector3.Lerp(currentPos, newPos, currentSpeed * Time.fixedDeltaTime);
        }
        if (Vector2.Distance(transform.position, startingPos) > maxDistance)
            currentSpeed = Mathf.Pow(cameraFollowSpeed, 2);
        else
            currentSpeed = cameraFollowSpeed;            
    }
}
