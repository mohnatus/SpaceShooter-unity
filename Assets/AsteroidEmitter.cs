﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitter : MonoBehaviour
{

    public float minDelay;
    public float maxDelay;

    public GameObject[] asteroidTypes;

    private float nextSpawn;
    private float asteroidCount = 1;

    public float maxAsteroidWave;

    GameObject GetRandomAsteroid()
    {
        int randomAsteroid = Random.Range(0, asteroidTypes.Length);
        Debug.Log(randomAsteroid);
        return asteroidTypes[randomAsteroid];
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            float maxAsteroid = Random.Range(1, asteroidCount);
            for (int i = 0; i < maxAsteroid; i++)
            {
                nextSpawn = Time.time + Random.Range(minDelay, maxDelay);
                float randomXPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                float randomZPosition = transform.position.z + Random.Range(0, 5);

                Vector3 startPosition = new Vector3(
                    randomXPosition,
                    transform.position.y,
                    randomZPosition
                );


                GameObject asteroid = GetRandomAsteroid();

                Instantiate(asteroid, startPosition, Quaternion.identity);
            }

            asteroidCount = Mathf.Min(asteroidCount + 0.3f, maxAsteroidWave);
            
        }
    }
}
