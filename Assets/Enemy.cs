using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Speed of movement
    private Transform player;

    private void Start()
    {
        // Find the player by tag (Make sure your player has the tag "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the object that collided with the enemy
        GameObject otherObject = collision.gameObject;

        // Destroy the enemy if it collides with a bullet or player
        if (otherObject.CompareTag("Bullet") || otherObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the enemy

            if (otherObject.CompareTag("Bullet"))
            {
                Destroy(otherObject); // Destroy the bullet instead of the enemy again
            }
        }
    }




}
