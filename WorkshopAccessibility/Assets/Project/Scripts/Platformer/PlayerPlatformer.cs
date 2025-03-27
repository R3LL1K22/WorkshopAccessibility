using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPlatformer : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float airControlFactor = 0.5f;
    [SerializeField] private float distanceWall = 0.1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        
        if (UserInput.instance.JumpJustPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveInput = UserInput.instance.MoveInput.x;
        
        float currentMoveSpeed = moveSpeed;
        if (!isGrounded)
        {
            currentMoveSpeed *= airControlFactor;
        }
        
        bool isNearWallLeftTop = Physics2D.Raycast(transform.position, Vector2.left + Vector2.up, distanceWall, groundLayer);
        bool isNearWallLeftMiddle = Physics2D.Raycast(transform.position, Vector2.left, distanceWall, groundLayer);
        bool isNearWallLeftBot = Physics2D.Raycast(transform.position, Vector2.left+ Vector2.down, distanceWall, groundLayer);
        
        bool isNearWallRightTop = Physics2D.Raycast(transform.position, Vector2.right + Vector2.up, distanceWall, groundLayer);
        bool isNearWallRightMiddle = Physics2D.Raycast(transform.position, Vector2.right, distanceWall, groundLayer);
        bool isNearWallRightBot = Physics2D.Raycast(transform.position, Vector2.right + Vector2.down, distanceWall, groundLayer);
        
        if (((isNearWallLeftTop || isNearWallLeftMiddle || isNearWallLeftBot) && moveInput < 0) || ((isNearWallRightTop || isNearWallRightMiddle || isNearWallRightBot) && moveInput > 0))
        {
            Debug.Log("should glisser");
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(moveInput * currentMoveSpeed, rb.linearVelocity.y);
        }
    }
}