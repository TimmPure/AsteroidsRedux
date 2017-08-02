using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamageHandler : MonoBehaviour {

    public int health = 1;
    public int asteroidSize = 3;
    public GameObject[] asteroids;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != gameObject.tag)
        {
            health--;
            if(health <= 0)
            {
                if (asteroidSize > 0)
                {
                    SpawnSmaller();
                }
                Destroy(gameObject);
            }
        }
    }

    private void SpawnSmaller()
    {
        Instantiate(asteroids[asteroidSize - 1]);
    }
}
