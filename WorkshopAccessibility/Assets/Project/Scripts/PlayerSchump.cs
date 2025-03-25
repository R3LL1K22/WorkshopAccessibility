using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSchump : MonoBehaviour
{
    [SerializeField] private InputAction playerMovement;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileDelay;
    
    private int life = 3;
    private float time = 0.0f;
    private Vector2 moveDirection = Vector2.zero;

    void OnEnable()
    {
        playerMovement.Enable();
    }

    void OnDisable()
    {
        playerMovement.Disable();
    }

    private void Update()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
        
        time += Time.deltaTime;
        if (time >= projectileDelay)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            time = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void takeDamage()
    {
        Debug.Log("Player taking damage");
        life--;
        if (life <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead");
    }
}
