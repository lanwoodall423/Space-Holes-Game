using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Player player;
    public GameObject playerShip;
    private Color playerColor;
	public AudioSource damageSound;

    public float mobility;

    public float horizontalRotation = 0f;
    public float verticalRotation = 0f;
    public float horizontalPosition;



    void Start()
    {
        playerShip = this.gameObject;
        player = GameObject.Find("Player").GetComponent<Player>();
        playerColor = playerShip.GetComponentInChildren<MeshRenderer>().material.color;
		damageSound = GameObject.Find ("damageSnd").GetComponent<AudioSource> ();
    }



    void FixedUpdate()
    {

        if (Input.GetKey("d"))
        {
            if (horizontalRotation >= -45f)
                horizontalRotation -= mobility;
        }
        if (Input.GetKey("a"))
        {
            if (horizontalRotation <= 45f)
                horizontalRotation += mobility;
        }
        if (Input.GetKey("w"))
        {
            if (verticalRotation >= -45f)
                verticalRotation -= mobility;
        }
        if (Input.GetKey("s"))
        {
            if (verticalRotation <= 45f)
                verticalRotation += mobility;
        }

        //Slowly return to vertical 0
        if (!Input.GetKey("s") && !Input.GetKey("w"))
        {
            if (verticalRotation > 0)
            {
                verticalRotation -= Mathf.Round(mobility / 5);
            }
            else if (verticalRotation < 0 && !Input.GetKey("w"))
            {
                verticalRotation += Mathf.Round(mobility / 5);
            }
        }

        //Slowly return to horizontal 0
        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            if (horizontalRotation > 0 && !Input.GetKey("d"))
            {
                horizontalRotation -= Mathf.Round(mobility / 5);
            }
            else if (horizontalRotation < 0 && !Input.GetKey("a"))
            {
                horizontalRotation += Mathf.Round(mobility / 5);
            }
        }

        playerShip.transform.localEulerAngles = new Vector3(verticalRotation, playerShip.transform.localEulerAngles.y, horizontalRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
			player.damagePlayer (0.5f);
			StartCoroutine (playerHit ());
    }

    IEnumerator playerHit()
    {
        playerShip.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
		damageSound.Play();
        yield return new WaitForSeconds(.5f);
        playerShip.GetComponentInChildren<MeshRenderer>().material.color = playerColor;

    }
}
