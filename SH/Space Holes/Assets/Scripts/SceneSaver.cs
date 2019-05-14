using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{
    public GameObject scene;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(scene);
        DontDestroyOnLoad(this);
    }

    public void loadSavedScene()
    {
        scene.SetActive(true);
    }
}
