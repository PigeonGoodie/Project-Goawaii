using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnTime;

    private float spawnTimer = 0;
    private GameObject enemy;

    void Update()
    {
        if (enemy != null) return;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            spawnTimer = spawnTime;
            enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
        }

    }
}