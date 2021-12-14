using UnityEngine;

public class PolyPad : MonoBehaviour
{
    [SerializeField] float bounceForce;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 veloc = playerRB.velocity;
            playerRB.AddForce(veloc.normalized + Vector2.up  * bounceForce, ForceMode2D.Impulse);
        }
    }
}
