using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelPhaseController : MonoBehaviour
{
    public GameObject playerShip;
	public GameObject statBars;

	// Use this for initialization
	void Start () {
		statBars = StarShipController.statBars;
		statBars.SetActive (true);
		createShip();
	}
	
	// Update is called once per frame
	void createShip()
    {
        //Instantiate ship and set parent to ShipHolder
        playerShip = Instantiate(Player.instance.currentShip);

        //set gameobjects location
        playerShip.transform.position = new Vector3(0f, 0.75f, -8);
        playerShip.transform.localScale = new Vector3(1, 1, 1);

        //add rigid body to ship
        playerShip.AddComponent<Rigidbody>();
        playerShip.GetComponent<Rigidbody>().useGravity = false;
        playerShip.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        //add the ship controller to the gameobject and set range
        playerShip.AddComponent<ShipController>();
        playerShip.GetComponent<ShipController>().mobility = 3;

        playerShip.transform.SetParent(this.transform);
    }
}
