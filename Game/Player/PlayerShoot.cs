using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bulletSpeed = 20;

    private readonly float timeBetweenShots = 0.2f;

    private float lastFireTime;
    private float timeSinceLastFire;

    private GameObject bullet;
    private Rigidbody2D rb;

    private bool isPlayerShooting;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isPlayerShooting = true;
        } else
        {
            isPlayerShooting = false;
        }
    }

    private void FixedUpdate()
    {
        timeSinceLastFire = Time.time - lastFireTime;
        // If there is no input or the player presses spacebar before the delay ended
        // prevent the method that allows the player to shoot to be executed
        if (!isPlayerShooting)
        {
            return;
        }

        if (timeSinceLastFire < timeBetweenShots)
        {
            return;
        }

        FireBullet();
        // Reset delay
        lastFireTime = Time.time;
    }

    private void FireBullet()
    {
        bullet = ObjectPool.instance.GetPlayerPooledObject();
        rb = bullet.GetComponent<Rigidbody2D>();
        // Set the position and rotation of the bullet to the player
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        // Activates a bullet from the bullet pool if its not empty
        if (bullet != null)
        {
            bullet.SetActive(true);
        }
        rb.velocity = bulletSpeed * transform.up;
    }
}