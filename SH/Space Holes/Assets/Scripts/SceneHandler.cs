using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneHandler : MonoBehaviour {

    /*
     * 
     *  You can use this to change scenes in any script easily using:
     *  
     *  SceneHandler.instance.changeScene(int nextSceneIndex);
     *  SceneHandler.instance.changeScene(int nextSceneIndex, int loadingSceneIndex);
     *  SceneHandler.instance.changeScene(int nextSceneIndex, int loadingSceneIndex, float delay);
     * 
     */

    public static SceneHandler instance;

    public static event Action<int> sceneChange;

    //Build Index of the current scene
    public int currentScene;

    //Store these Starmap GameObjects to be able to reactivate them
    private GameObject starmap;

    void Start () {
        instance = this;
        currentScene = SceneManager.GetActiveScene().buildIndex;

        starmap = GameObject.Find("Starmap");

    }



    //Properly load the next scene
    public void changeScene(int nextScene)
    {
        //Send scene change notification to any subscribers
        if(sceneChange != null)
        {
            sceneChange(nextScene);
        }

        if(currentScene != nextScene) {
            //If you're going to the Starmap
            if (nextScene == 1)
            {
                StartCoroutine(setActiveScene(nextScene));

                //set Starmap and StarmapShip active
                starmap.SetActive(true);

                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(currentScene));

                currentScene = 1;
            }

            //If you're going from the Starmap
            else if (currentScene == 1)
            {
                //set Starmap and StarmapShip inactive
                starmap.SetActive(false);

                currentScene = nextScene;

                SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
                StartCoroutine(setActiveScene(nextScene));


            }

            //If you're going between non-perpetual scenes
            else
            {
                SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
                StartCoroutine(setActiveScene(nextScene));
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(currentScene));
                currentScene = nextScene;
            }
        }
        //If you're going to the Starmap

    }



    //Properly load a loading scene while the next scene is loading, then switch when the timer is up.
    public void changeScene(int nextScene, int loadingScene, float delay)
    {
        //load loading scene, set it active, load nextscene, set it active when it's done loading, unload loading scene


        //If you're going to the Starmap
        if (nextScene == 1)
        {
            SceneManager.LoadScene(loadingScene, LoadSceneMode.Additive);
            StartCoroutine(setActiveScene(loadingScene));
            StartCoroutine(setActiveScene(nextScene, delay));

            //set Starmap and StarmapShip active
            starmap.SetActive(true);

            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(currentScene));

            currentScene = 1;
        }

        //If you're going from the Starmap
        else if (currentScene == 1)
        {
            //set Starmap and StarmapShip inactive
            starmap.SetActive(false);

            currentScene = nextScene;

            SceneManager.LoadScene(loadingScene, LoadSceneMode.Additive);
            SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
            StartCoroutine(setActiveScene(loadingScene));
            StartCoroutine(setActiveScene(nextScene, delay));


        }

        //If you're going between non-perpetual scenes
        else
        {
            SceneManager.LoadScene(loadingScene, LoadSceneMode.Additive);
            SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
            StartCoroutine(setActiveScene(loadingScene));
            StartCoroutine(setActiveScene(nextScene, delay));
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(currentScene));
            currentScene = nextScene;
        }
    }

    IEnumerator setActiveScene(int nextScene)
    {
        yield return new WaitForSeconds(.1f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(nextScene));
    }

    IEnumerator setActiveScene(int nextScene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(nextScene));
    }
}
