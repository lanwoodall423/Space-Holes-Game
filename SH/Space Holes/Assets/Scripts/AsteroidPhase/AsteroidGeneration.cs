using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidGeneration : MonoBehaviour
{
    public GameObject asteroidHolder;

    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;

    public int num;

    public float xpos;
    public float ypos;
    public float zpos;
    public Vector3 position;

    public float duration;
    public float speed;

    private void Start()
    {
        asteroidHolder = GameObject.Find("Asteroids");
        asteroid1 = Resources.Load("Asteroids/Asteroid 1") as GameObject;
        asteroid2 = Resources.Load("Asteroids/Asteroid 2") as GameObject;
        asteroid3 = Resources.Load("Asteroids/Asteroid 3") as GameObject;

        asteroid1.GetComponent<AsteroidController>().speed = speed;
        asteroid2.GetComponent<AsteroidController>().speed = speed;
        asteroid3.GetComponent<AsteroidController>().speed = speed;
    }

    void Update()
    {
        if (duration > 0)
        {
            num = Random.Range(1, 4);
            xpos = Random.Range(-15.0f, 15.0f);
            ypos = Random.Range(-15.0f, 15.0f);
            position = new Vector3(xpos, ypos, zpos);

            if (num == 1)
            {
                GameObject a1Clone = Instantiate(asteroid1, position, Quaternion.identity);
                a1Clone.transform.parent = asteroidHolder.transform;
                float randomScale = Random.Range(0.5f, 2.0f);
                a1Clone.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                Destroy(a1Clone, 4.0f);
            }
            else if (num == 2)
            {
                GameObject a2Clone = Instantiate(asteroid2, position, Quaternion.identity);
                a2Clone.transform.parent = asteroidHolder.transform;
                float randomScale = Random.Range(0.5f, 2.0f);
                a2Clone.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                Destroy(a2Clone, 4.0f);
            }
            else if (num == 3)
            {
                GameObject a3Clone = Instantiate(asteroid3, position, Quaternion.identity);
                a3Clone.transform.parent = asteroidHolder.transform;
                float randomScale = Random.Range(0.5f, 2.0f);
                a3Clone.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                Destroy(a3Clone, 4.0f);
            }
            duration -= Time.deltaTime;

        }
        if (duration < -2)
        {
			SceneHandler.instance.changeScene(10);
        }
        else
        {
            duration -= Time.deltaTime;
        }

    }
}
