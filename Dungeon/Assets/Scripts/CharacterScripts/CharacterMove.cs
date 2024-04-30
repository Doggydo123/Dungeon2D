using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to change movement speed
    public int stepsAfterCollision = 5; // Adjust this to change the number of steps to walk after collision

    public float radiusCheck = 1;
    private Rigidbody2D rb;
    private Animator myAnimator;

    private bool left = false;
    private bool right = false;
    private bool up = false;
    private bool down = false;
    private bool idle = true;

    private int remainingSteps = 0;

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
            int[] wall = CheckForColliders();
            //top
            if(wall.Length > 0){
                if(wall.Contains(0)){
                    if(moveVertical > (float)0){
                        moveVertical = 0;
                    }
                    //bottom
                }else if(wall.Contains(1)){
                    if(moveVertical < (float)0){
                        moveVertical = 0;
                    }
                    //right
                }
                
                if(wall.Contains(2)){
                    if(moveHorizontal > (float)0){
                        moveHorizontal = 0;
                    }
                    //left
                }else if(wall.Contains(3)){
                    if(moveHorizontal < (float)0){
                        moveHorizontal = 0;
                    }
                }
            }
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
            if (left)
            {
                myAnimator.Play("RobotLeft");
            }
            else if (right)
            {
                myAnimator.Play("RobotRight");
            }
            else if (up)
            {
                myAnimator.Play("RobotUp");
            }
            else if (down)
            {
                myAnimator.Play("RobotDown");
            }
            else
            {
                myAnimator.Play("RobotIdle");
            }
            
            // Check for colliders here

        }
        else
        {
            // If any option box is active, prevent movement
            rb.velocity = Vector2.zero;
            myAnimator.Play("RobotIdle");
        }
    }

    int[] CheckForColliders()
    {
        // Example of checking for colliders using OverlapCircle
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, (float).01);
        List<int> walls = new List<int>();
        foreach (Collider2D collider in colliders)
        {
            // Check for specific tags or layers if needed
            if (collider.CompareTag("TopWall"))
            {
                walls.Add(0);
            }
            else if (collider.CompareTag("BotWall"))
            {
                // Handle collision with item
                walls.Add(1);
            }
            if (collider.CompareTag("RightWall"))
            {
                // Handle collision with item
                walls.Add(2);
            }
            else if (collider.CompareTag("LeftWall"))
            {
                // Handle collision with item
                walls.Add(3);
            }
        }
        return walls.ToArray();
    }


}
