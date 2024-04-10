using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to change movement speed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Check if any option box is active
        if (!OptionBoxManager.isOptionBoxOpen)
        {
            // Get input from the player
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Calculate the movement direction
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            // Move the player
            rb.velocity = movement * speed;
        }
        else
        {
            // If any option box is active, prevent movement
            rb.velocity = Vector2.zero;
        }
    }
}

