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
    [SerializeField] GlobalVector2 movement;
    [SerializeField] GlobalBool canMove;
    [SerializeField] GlobalBool canJump;
    [SerializeField] GlobalBool isAttacking;
    [SerializeField] GlobalBool isMoving;
    [SerializeField] GlobalBool hasJumped;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        MovePlayer();
        if (Physics2D.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer))
        {
            canJump.Value = true;
        }
        else hasJumped.Value = false;
    }

    public void OnMove(InputValue move) => movement.Value = move.Get<Vector2>();

    public void OnJump()
    {
         if (canJump.Value)
         {
            rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
            hasJumped.Value = true;
         }
    }

    void MovePlayer()
    {
        if (canMove.Value && !isAttacking.Value)
        {
            isMoving.Value = true;
            Vector3 moveVector = speed * movement.Value;
            float yVeloc = rb.velocity.y;
            yVeloc = yVeloc > 0 ? yVeloc -= jumpMod * Time.fixedDeltaTime : yVeloc < 0 ? yVeloc -= fallRate * Time.fixedDeltaTime : yVeloc;
            rb.velocity = new Vector3(moveVector.x, yVeloc, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
            isMoving.Value = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.down * groundCheckDistance);
    }
}