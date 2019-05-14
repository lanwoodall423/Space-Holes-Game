using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    protected static Player _instance;
    public static Player instance;

    //All Player Stats, currency, etc
    #region Stats
    //Health
    public float currentHealth;
    public float maxHealth;
    public Text healthNumbers;
    public Image healthBar;

    //Fuel
    public float currentFuel;
    public float maxFuel;
    public Text fuelNumbers;
    public Image fuelBar;

    //Weight
    public float currentWeight;
    public float maxWeight;
    public Text weightNumbers;
    public Image weightBar;

    //Ammo
    public float ammoDmgModifier;
    public float reloadTimeModifier;
    public int clipSizeModifier;
    public int maxAmmoModifier;

    public float currentAmmo;
    public float maxAmmo;
    public Text ammoNumbers;
    public Image ammoBar;

    //Currency
    public Text currencyText;
    public int currencyAmount;
    #endregion
    public GameObject currentShip;

    public GameObject scene;
    public int sceneNumber;
    public ulong mySeed;
    public Camera mainCamera;

    //Notifies subscribers that the ship has set 
    public static Action<GameObject> shipUpdated;

    void Start()
    {
        //Initialize variables
        instance = this;
        sceneNumber = 1;

        currentHealth = maxHealth;
        currentFuel = maxFuel;
        currentWeight = 0;
        currentAmmo = maxAmmo;
        currencyAmount = 0;

        ammoDmgModifier = 0;
        reloadTimeModifier = 0;
        clipSizeModifier = 1;
        maxAmmoModifier = 0;

    updateDisplay();

        DontDestroyOnLoad(scene);

        //Set starter ship first
        setShip("Ships/AstraBattleShip");
    }



    void Update()
    {
        updateDisplay();
        /*
        if (Input.GetKeyUp("i"))
        {
            setShip("Ships/AstraFighter01");
        }
        */
    }

    public void updateDisplay()
    {
        healthBar.rectTransform.localScale = new Vector3((currentHealth / maxHealth), 1, 1);
        fuelBar.rectTransform.localScale = new Vector3((currentFuel / maxFuel), 1, 1);
        weightBar.rectTransform.localScale = new Vector3((currentWeight / maxWeight), 1, 1);
        ammoBar.rectTransform.localScale = new Vector3((currentAmmo / maxAmmo), 1, 1);

        healthNumbers.text = Mathf.Round(currentHealth).ToString() + " / " + maxHealth.ToString();
        fuelNumbers.text = Mathf.Round(currentFuel).ToString() + " / " + maxFuel.ToString();
        weightNumbers.text = Mathf.Round(currentWeight).ToString() + " / " + maxWeight.ToString();
        ammoNumbers.text = Mathf.Round(currentAmmo).ToString() + " / " + maxAmmo.ToString();

        currencyText.text = currencyAmount.ToString() + " ?s";
    }

    public void damagePlayer(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            //Add retry function
            SceneManager.LoadScene(7);
        }
    }

    //Set the player's current ship
    public void setShip(string shipPath)
    {
        currentShip = Resources.Load<GameObject>(shipPath);
        //Send notification
        if (shipUpdated != null)
        {
            shipUpdated(currentShip as GameObject);
        }
    }
}
