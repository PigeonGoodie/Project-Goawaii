using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnTime;

    public float despawnDistance;
    public float minSpawnDistance = 5;

    private float spawnTimer = 0;
    private GameObject enemy;

    public bool doRespawn = true;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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

        if (spawnTimer <= 0 && Vector3.Distance(player.transform.position, transform.position) > minSpawnDistance)
        {
            spawnTimer = spawnTime;
            enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
        }
    }
}