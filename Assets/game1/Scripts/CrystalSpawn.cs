using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawn : MonoBehaviour
{
    public GameObject[] Crystal;
    public float secondsBetweenSpawn;
    public float elapsedTime;

    private Transform SpawnPoint;

    private void Start()
    {
        SpawnPoint = GetComponent<Transform>();
        
    }
    void Update()
    {
        secondsBetweenSpawn = Random.Range(5.0f,7.0f);
        elapsedTime += Time.deltaTime;
        if (elapsedTime > secondsBetweenSpawn)
        {
            int index = Random.Range(0, Crystal.Length);
            float newEnemySpawnTime = Time.time + secondsBetweenSpawn;
            Vector3 spawnPosition = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, SpawnPoint.position.z);
            GameObject newEnemy = (GameObject)Instantiate(Crystal[index], spawnPosition, Quaternion.Euler(0, 0, 0));
            Destroy(newEnemy, 40f);
            elapsedTime = 0;
        }
    }
}