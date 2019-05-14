using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealthBar : MonoBehaviour {

    // Use this for initialization
    public GameObject loadingScreenObj;
    public Slider slider;

    GameObject enemy;
    CorvetteHealth vetHealth;

    private void Start()
    {
        enemy = GameObject.Find("CorvetteController");
        vetHealth = enemy.GetComponent<CorvetteHealth>();

        slider.maxValue = vetHealth.health;
    }
    // Update is called once per frame
    void Update () {
        manageHealth();
	}

    void manageHealth()
    {
        slider.value = enemy.GetComponent<CorvetteHealth>().health;
    }
}
