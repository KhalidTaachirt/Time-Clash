using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    protected float enemyShootTimer;
    protected float enemyShootDelay = 3f;
    protected float enemyBulletSpeed = 5f;

    private GameObject enemyBullet;

    private Rigidbody2D rb;

    private EnemyMovement enemyMovement;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void FixedUpdate()
    {
        enemyShootTimer += Time.deltaTime;

        // Shoots a bullet every time the delay ends
        if (enemyShootTimer > enemyShootDelay && enemyMovement != null && enemyMovement.enemyAwareness)
        {
            enemyShootTimer = 0;
            EnemyShoots();
        }
    }

    /// <summary>
    /// Shoots a bullet from the enemy bullets pool
    /// </summary>
    public virtual void EnemyShoots()
    {
        enemyBullet = ObjectPool.instance.GetEnemyPooledObject();
        rb = enemyBullet.GetComponent<Rigidbody2D>();
        // Sets the position and rotation of the bullet to the enemy's
        enemyBullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        // Activates bullet in object pool if its not empty
        if (enemyBullet != null)
        {
            enemyBullet.SetActive(true);
        }

        rb.velocity = transform.up * enemyBulletSpeed;
    }
}
