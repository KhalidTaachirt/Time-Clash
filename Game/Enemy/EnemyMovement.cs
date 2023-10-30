using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float enemyAwarenessDistance = 30f;

    protected float rotationSpeed = 1.8f;
    protected float distanceBetweenPlayerAndEnemy;

    private float angle;

    private Vector2 direction;

    public bool enemyAwareness = false;

    protected GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }
    
    /// <summary>
    /// Moves the enemy towards the player if the enemy is aware
    /// </summary>
    public virtual void MoveEnemy()
    {
        // Calculates the distance between the position of the enemy and the player
        // and the direction that the enemy should take to go to the player
        distanceBetweenPlayerAndEnemy = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg * rotationSpeed;
        // Moves and rotates the enemy towards the player when the enemy is aware
        if (distanceBetweenPlayerAndEnemy < enemyAwarenessDistance)
        {
            enemyAwareness = true;
            transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position,
            player.transform.position, movementSpeed * Time.deltaTime),
            Quaternion.Euler(Vector3.forward * angle));
        }
        else
        {
            enemyAwareness = false;
        }
    }
}