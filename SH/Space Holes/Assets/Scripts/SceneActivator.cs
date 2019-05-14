using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActivator : MonoBehaviour {
	void Start () {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(SceneHandler.instance.currentScene));
    }
}
