using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamageHandler : MonoBehaviour {

    public int health = 1;
    public int asteroidSize = 3;
    public GameObject[] asteroids;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != gameObject.tag)
        {
            health--;
            if(health <= 0)
            {
                if (asteroidSize > 0)
                {
                    SpawnSmaller(coll);
                }
                Destroy(gameObject);
            }
        }
    }

    private void SpawnSmaller(Collision2D coll)
    {
        Vector2 directionOfHit = ((Vector2)transform.position - coll.contacts[0].point).normalized;
        Vector2 something = Quaternion.Euler(0, 0, 45) * directionOfHit;
        Vector2 spawnPosition = coll.contacts[0].point + something;
        GameObject obj = Instantiate(asteroids[asteroidSize - 1], spawnPosition, Quaternion.identity);
        obj.GetComponent<Asteroid>().randomVector = something.normalized;

        something = Quaternion.Euler(0, 0, -45) * directionOfHit;
        spawnPosition = coll.contacts[0].point + something;
        GameObject obj2 = Instantiate(asteroids[asteroidSize - 1], spawnPosition, Quaternion.identity);
        obj2.GetComponent<Asteroid>().randomVector = something.normalized;
    }
}
