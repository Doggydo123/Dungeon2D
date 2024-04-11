using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to change movement speed

    private Rigidbody2D rb;
    private Animator myAnimator;

    private bool left = false;
    private bool right = false;
    private bool up = false;
    private bool down = false;
    private bool idle = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        myAnimator = GetComponent<Animator>();
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

            // Determine the movement direction
            left = moveHorizontal < 0;
            right = moveHorizontal > 0;
            up = moveVertical > 0;
            down = moveVertical < 0;
            idle = !left && !right && !up && !down;

            // Set animator parameters based on movement direction
            if(left){
                myAnimator.Play("RobotLeft");
            }else if(right){
                myAnimator.Play("RobotRight");
            }else if(up){
                myAnimator.Play("RobotUp");
            }else if(down){
                myAnimator.Play("RobotDown");
            }else{
                myAnimator.Play("RobotIdle");
            }
        }
        else
        {
            // If any option box is active, prevent movement
            rb.velocity = Vector2.zero;
            myAnimator.Play("RobotIdle");
        }
    }
}
