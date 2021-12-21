using UnityEngine;

public class PolyPad : MonoBehaviour
{
    [SerializeField] float bounceForce;
    [SerializeField] AudioTrigger audioTrigger;
    [SerializeField] AudioSource source;
    [SerializeField] LayerMask playerLayer;
    
    void OnCollisionEnter2D(Collision2D other) {
        if (audioTrigger != null && source != null)
            audioTrigger.Trigger(source);
        if (Utils.IsInLayerMask(other.gameObject, playerLayer))
        {
            Rigidbody2D playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 veloc = playerRB.velocity;
            playerRB.AddForce(veloc.normalized + Vector2.up  * bounceForce, ForceMode2D.Impulse);
        }
    }
}
