using UnityEngine;
using UnityEngine.Events;

public class LaunchRigidbody : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] float force;
    [SerializeField] bool useColliderElseTrigger;
    [SerializeField] UnityEvent<GameObject> OnLaunchedObject;
    Vector2 otherNormVel = Vector2.zero;
    Rigidbody2D otherRB = null;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (useColliderElseTrigger)
            LaunchGameObject(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!useColliderElseTrigger)
            LaunchGameObject(other.gameObject);
    }

    void LaunchGameObject(GameObject obj)
    {
        otherRB = obj.GetComponent<Rigidbody2D>();
        if (otherRB != null)
        {
            otherNormVel = otherRB.velocity.normalized;
            OnLaunchedObject?.Invoke(obj);
            otherRB.AddForce(otherNormVel + (force * direction), ForceMode2D.Impulse);
        }
    }
}