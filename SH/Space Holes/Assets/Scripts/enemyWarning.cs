using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWarning : MonoBehaviour {

	public GameObject textHolder;
	bool isActive;
	int loopCount;

	// Use this for initialization
	void Start () {
		isActive = true;
		loopCount = 4;
		StartCoroutine(Blinking());
	}

	// Update is called once per frame
	IEnumerator Blinking () {
		while (loopCount > -1)
		{
			if (loopCount > 0) {
				if (isActive == true) {
					textHolder.SetActive (false);
					yield return new WaitForSeconds (seconds: .5f);
					isActive = false;
				}


				if (isActive == false) {
					textHolder.SetActive (true);
					yield return new WaitForSeconds (seconds: .5f);
					isActive = true;
				}


			} else if (loopCount <= 0) {
				SceneHandler.instance.changeScene(3);
			}

			loopCount -= 1;
		}  
	}
}
