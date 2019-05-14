using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorvetteHealth : MonoBehaviour {

    CorvetteController controller;
    public GameObject scene;
	public GameObject victory;
	public GameObject exitBtn;
	public AudioSource btnSound;

    [Tooltip("Whether the enemy is Destroyed or not")]
    public bool isDestroyed = false;

    [Tooltip("enemy Current Health")]
    public float health;
    [Tooltip("Total Health of the enemy in Start")]
    public float totalHealth = 100; //Should be used when repairing is done

    void Start()
    {
        controller = this.GetComponent<CorvetteController>();
		victory.SetActive (false);
		exitBtn.SetActive (false);

        health = Random.Range(10, 40);
    }

    //Apply damage to Turret
    public void ApplyDamage(float damage)
    {

        if (health - damage > 0)
        {

            health -= damage;

        }
        else
        {

            isDestroyed = true;
            health = 0;
			Time.timeScale = 0;
			victory.SetActive (true);
			exitBtn.SetActive(true);

            
        }

        controller._Audio.Play_GetHit();
    }

    public void shipDestroy()
    {
		btnSound.Play();
		Time.timeScale = 1;
		SceneHandler.instance.changeScene(1);
        /*
        GameObject savedSceneLoader = GameObject.Find("SceneTraverser");
        savedSceneLoader.GetComponent<SceneSaver>().loadSavedScene();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(3));
        */
    }

}
