using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private readonly float rotationSpeed = 360f;

    private Rigidbody2D rb;

    private PlayerMovement playerMovement;

    private Quaternion targetRotation;
    private Quaternion rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        RotateInDirectionOfInput();
    }

    private void RotateInDirectionOfInput()
    {
        if (playerMovement.moveDirection != Vector2.zero)
        {
            targetRotation = Quaternion.LookRotation(transform.forward, playerMovement.smoothedMovementInput);
            rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            // Rotate the character in the given direction
            rb.MoveRotation(rotation);
        }
    }
}