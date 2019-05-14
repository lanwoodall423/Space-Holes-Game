using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarGenMesser : MonoBehaviour {
    public GameObject stellarController;


	// Use this for initialization
	void Start () {
        stellarController = GameObject.Find("StellarGenController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
