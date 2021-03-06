using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn : MonoBehaviour
{
    public GameObject EnemyObject;
    public float secondsBetweenSpawn;
    public float elapsedTime;

    private Transform SpawnPoint;

    private void Start()
    {
        SpawnPoint = GetComponent<Transform>();
        
    }
    void Update()
    {
        secondsBetweenSpawn = Random.Range(7f, 10f);
        elapsedTime += Time.deltaTime;
        if (elapsedTime > secondsBetweenSpawn)
        {
            float newEnemySpawnTime = Time.time + secondsBetweenSpawn;
            Vector3 spawnPosition = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, SpawnPoint.position.z);
            GameObject newEnemy = (GameObject)Instantiate(EnemyObject, spawnPosition, Quaternion.Euler(0, 0, 0));
            Destroy(newEnemy, 60f);
            elapsedTime = 0;
        }
    }
}