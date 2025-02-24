using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Weapon weapon;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    void Update()
    {
        // Get movement input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Handle shooting
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        // Normalize movement direction
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Get mouse position in world coordinates
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        // Move player using Rigidbody velocity
        rb.linearVelocity = moveDirection * moveSpeed;

        // Rotate towards mouse position
        Vector2 aimDirection = (mousePosition - rb.position).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
