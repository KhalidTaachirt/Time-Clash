using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 15f;

    public Vector2 moveDirection;
    public Vector2 smoothedMovementInput;

    private Vector2 movementInputSmoothVelocity;

    private Rigidbody2D rb;

    private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void Update()
	{
        InputDirections();
    }

    private void FixedUpdate()
    {
        SmoothedPlayerMovement();
    }

    // Input directions of the player gets saved so that this can be accessed for the movement
    private void InputDirections()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
        }
        else
        {
            moveDirection.x = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1;
        }
        else
        {
            moveDirection.y = 0;
        }
    }

    public void SmoothedPlayerMovement()
    {
		// Allows the character to slow down when no input is found
		// instead of instantly standing still
        smoothedMovementInput = Vector2.SmoothDamp(
                    smoothedMovementInput,
                    moveDirection,
                    ref movementInputSmoothVelocity,
                    0.1f);

        // Allows the player to move towards the input direction
		rb.velocity = smoothedMovementInput * movementSpeed;
    }
}