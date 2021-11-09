using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerRigidMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpMod;
    [SerializeField] float fallRate;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckDistance;
    Vector3 movement = Vector3.zero;
    [SerializeField] GlobalBool canMove;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update() => MovePlayer();

    public void OnMove(InputValue move) => movement = move.Get<Vector2>();

    public void OnJump()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer))
            rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
    }

    void MovePlayer()
    {
        if (canMove.Value)
        {
            Vector3 moveVector = speed * movement;
            float yVeloc = rb.velocity.y;
            yVeloc = yVeloc > 0 ? yVeloc -= jumpMod * Time.fixedDeltaTime : yVeloc < 0 ? yVeloc -= fallRate * Time.fixedDeltaTime : yVeloc;
            rb.velocity = new Vector3(moveVector.x, yVeloc, 0);
        }
        else
            rb.velocity = Vector2.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.down * groundCheckDistance);
    }
}
