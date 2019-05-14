using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarController : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
		{
            Player.instance.currentHealth += 5;
            SceneHandler.instance.changeScene(5);        
		}
	}
}
