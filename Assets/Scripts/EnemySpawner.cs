using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xLimit = Player.xBorderLimit;
    public float maxTimeLife = 4f;

    private float spawnNext = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xLimit,xLimit);

            Vector2 spawnPosition = new Vector2(rand,Player.yBorderLimit+2);

            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            Destroy(meteor, maxTimeLife);
        }
    }
}
