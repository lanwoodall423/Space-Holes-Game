using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
    public Player player;

    public int mobility;
    public float rotation;
    public float speed;

    private void Start()
    {
        GameObject.Find("Player").GetComponent<Player>();
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotation;
        GetComponent<Rigidbody>().AddForce(transform.forward * -1 * speed, ForceMode.Impulse);
    }

    void Update () {
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - (Time.deltaTime * speed));
	}

	void FixedUpdate() {


		if (Input.GetKey("d"))
        {
			this.transform.position = new Vector3 (this.transform.position.x - (Time.deltaTime * mobility), this.transform.position.y, this.transform.position.z);
		}

		if (Input.GetKey("a"))
        {
			this.transform.position = new Vector3 (this.transform.position.x + (Time.deltaTime * mobility), this.transform.position.y, this.transform.position.z);
		}

		if (Input.GetKey("w")) 
        {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - (Time.deltaTime * mobility), this.transform.position.z);
		}

		if (Input.GetKey("s"))
        {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + (Time.deltaTime * mobility), this.transform.position.z);
		}
	}
}
