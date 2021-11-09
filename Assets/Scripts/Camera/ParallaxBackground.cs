using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] Vector3 effectMultiplier;
    Transform cameraTransform;
    Vector3 lastCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMove = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMove.x * effectMultiplier.x, deltaMove.y * effectMultiplier.y, transform.position.z);
        lastCameraPosition = cameraTransform.position;
    }
}