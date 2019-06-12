using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;

    public Transform[] spawnPoints;

    void Start ()
    {
        StartCoroutine ("SpawnWave", 1f);
    }

    void Update ()
    {
    }

    IEnumerator SpawnWave ()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = spawnPoints[Random.Range (0, spawnPoints.Length)].position;

            GameObject spawnedEnemy = Instantiate (enemy, spawnPos, transform.rotation) as GameObject;

            yield return new WaitForSeconds (0.5f);
        }
    }
}
