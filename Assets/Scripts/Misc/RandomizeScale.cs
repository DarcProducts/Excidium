using UnityEngine;

public class RandomizeScale : MonoBehaviour
{
    [SerializeField] Vector2 minMaxScale;
    float newScale = 0;

    void OnEnable()
    {
        newScale = Random.Range(minMaxScale.x, minMaxScale.y);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}