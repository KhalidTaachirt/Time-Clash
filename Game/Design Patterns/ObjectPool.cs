using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private readonly List<GameObject> playerPooledObjects = new();
    public List<GameObject> EnemyPooledObjects { get; private set; } = new();

    private PlayerBullet playerBullet;
    private EnemyBullet enemyBullet;

    private readonly int playerBulletsAmountToPool = 15;
    private readonly int enemyBulletsAmountToPool = 50;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        CreatePlayerBullets(playerBulletsAmountToPool);
        CreateEnemyBullets(enemyBulletsAmountToPool);
    }

    // For loop making a set amount of bullets at the start of the game
    // and setting them to false to prevent them from showing on the screen
    private void CreatePlayerBullets(int bulletAmount)
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            playerBullet = new("PlayerBullet", transform.position);
            playerBullet.GameObject.SetActive(false);
            playerPooledObjects.Add(playerBullet.GameObject);
        }
    }

    private void CreateEnemyBullets(int bulletAmount)
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            enemyBullet = new("EnemyBullet", transform.position);
            enemyBullet.GameObject.SetActive(false);
            EnemyPooledObjects.Add(enemyBullet.GameObject);
        }
    }

    // Returns the bullets that are available
    public GameObject GetPlayerPooledObject()
    {
        for (int i = 0; i < playerPooledObjects.Count; i++)
        {
            if (!playerPooledObjects[i].activeInHierarchy)
            {
                return playerPooledObjects[i];
            }
        }

        return null;
    }

    public GameObject GetEnemyPooledObject()
    {
        for (int i = 0; i < EnemyPooledObjects.Count; i++)
        {
            if (!EnemyPooledObjects[i].activeInHierarchy)
            {
                return EnemyPooledObjects[i];
            }
        }

        return null;
    }
}