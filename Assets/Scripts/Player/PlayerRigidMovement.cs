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
    [SerializeField] AnimatorTrigger moveTrigger;
    [SerializeField] AnimatorTrigger idleTrigger;
    [SerializeField] AnimatorTrigger attackTrigger;
    [SerializeField] AnimatorTrigger jumpTrigger;
    [SerializeField] AnimatorTrigger landTrigger;
    [SerializeField] GlobalBool canMove;
    [SerializeField] GlobalBool canJump;
    [SerializeField] GlobalBool isAttacking;
    [SerializeField] GlobalBool isMoving;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update() => MovePlayer();

    public void OnMove(InputValue move) => movement = move.Get<Vector2>();

    public void OnJump()
    {
        if (canJump.Value && Physics2D.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer))
            rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
    }

    void MovePlayer()
    {
        if (canMove.Value && !isAttacking.Value)
        {
            isMoving.Value = true;
            Vector3 moveVector = speed * movement;
            float yVeloc = rb.velocity.y;
            yVeloc = yVeloc > 0 ? yVeloc -= jumpMod * Time.fixedDeltaTime : yVeloc < 0 ? yVeloc -= fallRate * Time.fixedDeltaTime : yVeloc;
            rb.velocity = new Vector3(moveVector.x, yVeloc, 0);
            if (movement.x < 0)
                moveTrigger.Trigger(true);
            else if (movement.x > 0)
                moveTrigger.Trigger(false);
            else
            {
                idleTrigger.Trigger(true);
            }
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