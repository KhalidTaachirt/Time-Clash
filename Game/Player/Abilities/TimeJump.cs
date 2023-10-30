using UnityEngine;

public class TimeJump : MonoBehaviour
{
    private readonly float timeJumpCooldown = 2f;
    private readonly float dashSpeed = 0.4f;

    private float lastTimeJump;
    private float timeSinceLastJump;
    
    private TimeGauge timeGauge;
    private PlayerLives playerLives;
    private PlayerMovement playerMovement;

    private bool playerCanDash = false;

    private void Start()
    {
        timeGauge = FindObjectOfType<TimeGauge>();
        playerLives = FindObjectOfType<PlayerLives>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        timeSinceLastJump = Time.time - lastTimeJump;
        // Exit out of the method if there are no time shards left
        if (timeGauge.timeShards <= 0)
        {
            return;
        }
        // If the cooldown is active exit out of the method
        if (timeSinceLastJump < timeJumpCooldown)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerCanDash = true;  
        }
    }

    private void FixedUpdate()
    {
        if (playerCanDash)
        {
            TimeJumping();
            lastTimeJump = Time.time;
            playerLives.hit = true;
            playerCanDash = false;
        } 
    }

    // Allows the player to dash towards the input direction
    private void TimeJumping()
    {
        Vector2 currentPosition = transform.position;
   
        if (playerMovement.moveDirection.x > 0)
        {
            Vector2 newPosition = currentPosition + new Vector2(5f, 0f);
            transform.position = Vector2.Lerp(transform.position, newPosition, dashSpeed);
        }
        else if (playerMovement.moveDirection.x < 0)
        {
            Vector2 newPosition = currentPosition + new Vector2(-5f, 0f);
            transform.position = Vector2.Lerp(transform.position, newPosition, dashSpeed);
        }
        if (playerMovement.moveDirection.y > 0)
        {
            Vector2 newPosition = currentPosition + new Vector2(0f, 5f);
            transform.position = Vector2.Lerp(transform.position, newPosition, dashSpeed);
        }
        else if (playerMovement.moveDirection.y < 0)
        {
            Vector2 newPosition = currentPosition + new Vector2(0f, -5f);
            transform.position = Vector2.Lerp(transform.position, newPosition, dashSpeed);
        }
        // Consume time shard and add time shards used to the game metrics
        --timeGauge.timeShards;
        ++timeGauge.timeShardsUsed;
    }
}
