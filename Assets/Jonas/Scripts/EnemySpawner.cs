using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnTime;

    public float despawnDistance;

    private float spawnTimer = 0;
    private GameObject enemy;

    public bool doRespawn = true;

    void Update()
    {
        if (!doRespawn)
            return;

        if (enemy != null)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) > despawnDistance)
                Destroy(enemy);
            return;
        }

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            spawnTimer = spawnTime;
            enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
        }
    }
}