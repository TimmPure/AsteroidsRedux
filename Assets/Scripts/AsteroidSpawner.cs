using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject[] asteroidPrefabs;
    
    public float minSpawnTime, maxSpawnTime;
    public float spawnScreenPadding;
    public float maxAsteroids;

    private float timeToSpawn;
    private Transform asteroidsParent;

    // Use this for initialization
    void Start () {
        timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        asteroidsParent = GameObject.Find("Asteroids").transform;
	}
	
	// Update is called once per frame
	void Update () {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn <= 0 && asteroidsParent.childCount < maxAsteroids) {
            SpawnAsteroid();
            timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        }
	}

    void SpawnAsteroid() {
        GameObject asteroidToSpawn = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length - 1)];

        int spawnLocation = Random.Range(0, 3); // spawn locations: 0 = top; 1 = right; 2 = bottom; 3 = left
        Vector3 spawnPosition = Vector2.zero;
        Vector3 target = Vector2.zero;
        Vector3 velocity = Vector2.zero;

        switch (spawnLocation) {
            case 0:
                spawnPosition.x = Random.Range(0, 1f);
                spawnPosition.y = 1f + spawnScreenPadding;

                target.x = Random.Range(0.3f, 0.7f);
                target.y = 1f;
                break;
            case 1:
                spawnPosition.x = 1f + spawnScreenPadding;
                spawnPosition.y = Random.Range(0f, 1f);

                target.x = 1f;
                target.y = Random.Range(0.3f, 0.7f);
                break;
            case 2:
                spawnPosition.x = Random.Range(0f, 1f);
                spawnPosition.y = 0f - spawnScreenPadding;

                target.x = Random.Range(0.3f, 0.7f);
                target.y = 0f;
                break;
            case 3:
                spawnPosition.x = 0f - spawnScreenPadding;
                spawnPosition.y = Random.Range(0.3f, 0.7f);

                target.x = 0f;
                target.y = Random.Range(0f, 1f);
                break;

        }

        spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
        target = Camera.main.ViewportToWorldPoint(target);

        Vector2 movementDirection = (target - spawnPosition).normalized;

        GameObject asteroid = Instantiate(asteroidToSpawn, spawnPosition, Quaternion.identity);

        asteroid.GetComponent<Asteroid>().randomVector = movementDirection;
        asteroid.GetComponent<PolygonCollider2D>().enabled = false;

    }
}
