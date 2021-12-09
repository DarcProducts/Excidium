using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRigidMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int maxSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpMod;
    [SerializeField] float fallRate;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckDistance;
    public Vector2 movement;
    [SerializeField] GlobalBool canMove;
    [SerializeField] GlobalBool canJump;
    [SerializeField] GlobalBool justJumped;

    [SerializeField] GlobalBool isAttacking;
    [SerializeField] GlobalBool isMoving;
    public static Vector2 currentSpawnLocation;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Start() => currentSpawnLocation = transform.position;

    void Update() => MovePlayer();

    public void OnMove(InputValue move) => movement = move.Get<Vector2>();

    public void OnJump()
    {
        if (canJump.Value)
        {
            if (Physics2D.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer))
            {
                if (rb.velocity.magnitude < maxSpeed)
                {
                    rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
                    justJumped.Value = true;
                }
            }
        }        
    }

    void MovePlayer()
    {
        float currentSpeed = rb.velocity.magnitude;
        if (currentSpeed > maxSpeed)
            rb.velocity = rb.velocity.normalized * currentSpeed;
        if (canMove.Value && !isAttacking.Value)
        {
            isMoving.Value = true;
            Vector3 moveVector = speed * movement;
            float yVeloc = rb.velocity.y;
            yVeloc = yVeloc > 0 ? yVeloc -= jumpMod * Time.fixedDeltaTime : yVeloc < 0 ? yVeloc -= fallRate * Time.fixedDeltaTime : yVeloc;
            if (rb.velocity.magnitude < maxSpeed)
                rb.velocity = new Vector3(moveVector.x, yVeloc, 0);
            justJumped.Value = false;
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