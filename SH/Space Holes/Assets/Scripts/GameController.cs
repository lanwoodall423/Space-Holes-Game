using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum GameState { MENU, MENU_TO_PLAYING, PAUSED, PLAYING, PLAYING_TO_MENU, PLAYING_TO_WIN, WIN }
public enum MenuState { MAIN, INGAME, PAUSE, WIN }

public class GameController : MonoBehaviour 
{
	public GameState gameState;                //The current gamestate
	public MenuState menuState;				   //The current menustate

	public Text seedTracker;                   //Displays the current seed

	public GameObject MainMenu;                //Object that represents the main menu
	public GameObject InGameMenu;              //Object that represents the in game menu
	public GameObject PauseMenu;               //Object that represents the pause menu
	public GameObject WinMenu;                 //Object that represents the win menu
	public GameObject HowTo;			       //Shows the game instructions

	public AudioSource btnSound;               //The audio source for the sound effect played when a button is clicked

    public GameObject developButton;           //Allows us to enter developer mode
    public GameObject DeveloperMenu;           //Object that represents the developer menu

    public GameObject EnterSolar; 				  //Allows the player to enter a solar system;
    public GameObject ExitSolar; 				  //Allows the player to exit a solar system;



	void Start () {
		ExitSolar.SetActive(false);
		Time.timeScale = 1; //Just making sure that the timeScale is right
		switchToPlaying();
	}
	


	void Update() 
	{
		Application.targetFrameRate = 60;
		seedTracker.text = Player.instance.mySeed.ToString();
		switch (gameState) 
		{
		case GameState.MENU:
			if (Input.GetKeyDown(KeyCode.KeypadEnter)) 
			{
				gameState = GameState.MENU_TO_PLAYING;
			}
			break;


		case GameState.MENU_TO_PLAYING:
			switchToPlaying();
			break;


		case GameState.PAUSED:
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				gameState = GameState.MENU_TO_PLAYING;
			}
            
			//Enables developer button on d key press
			if (Input.GetKeyDown(KeyCode.D)) 
			{
				//Enables the developer mode button
                developButton.SetActive(true);
			}

			//Disables developer button on f key press
			if (Input.GetKeyDown(KeyCode.F))  
			{
				//Disables the developer mode button
				developButton.SetActive(false);

				//Prevents the developer menu from appearing
				DeveloperMenu.SetActive(false);
			}
			break;


		case GameState.PLAYING:

            //Disables the developer mode button
            developButton.SetActive(false);

			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
				gameState = GameState.PLAYING_TO_MENU;
			}
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                ExitSolar.SetActive(true);
            }
            else
            {
                ExitSolar.SetActive(false);
            }
            break;


		case GameState.PLAYING_TO_MENU:
			switchToPauseMenu();
			break;


		default:
			break;
		}
	}

	public void switchToPlaying() 
	{
		btnSound.Play ();                    //Plays button click sound effect

		gameState = GameState.PLAYING;       //Changes the gamestate to the playing state

		MainMenu.SetActive(false);           //Prevents the main menu from appearing
		InGameMenu.SetActive(true);          //Allows the in game menu to appear
		PauseMenu.SetActive(false);          //Prevents the pause menu from appearing
		WinMenu.SetActive(false);            //Prevents the win menu from appearing
		HowTo.SetActive(false);              //Prevents the game instructions from apearing
		DeveloperMenu.SetActive(false);      //Prevents the developer menu from appearing

		Time.timeScale = 1;          		 //Unpauses the game
		EnableMouseLook();                   //Enables movement of the camera direction
		EnableCameraControl();               //Enables control of the camera
	}

	public void switchToPauseMenu() 
	{
		gameState = GameState.PAUSED;         //Changes the gamestate to the paused state

		MainMenu.SetActive(false);            //Prevents the main menu from appearing
		InGameMenu.SetActive(false);          //Prevents the in game menu from appearing
		PauseMenu.SetActive(true);            //Allows the pause menu to appear
		WinMenu.SetActive(false);             //Prevents the win menu from appearing
		HowTo.SetActive(true);                //Shows the game instructions
		DeveloperMenu.SetActive(false);       //Prevents the developer menu from appearing

		Time.timeScale = 0;          		  //Pauses the game
		DisableMouseLook();                   //Disables movement of the camera direction
		DisableCameraControl();               //Disables control of the camera
	}

	public void switchToMainMenu() 
	{
		gameState = GameState.MENU;           //Changes the gamestate to the menu gamestate

		MainMenu.SetActive(true);             //Allows the main menu to appear
		InGameMenu.SetActive(false);          //Prevents the in game menu from appearing
		PauseMenu.SetActive(false);           //Prevents the pause menu from appearing
		HowTo.SetActive(true);                //Shows the game instructions
		DeveloperMenu.SetActive(false);       //Prevents the developer menu from appearing

		Time.timeScale = 0;                   //Pauses the game
	}

	public void quitGame() 
	{
		btnSound.Play ();             //Plays button click sound effect
		Application.Quit();          //Quits the game
	}

	private void DisableMouseLook()
	{
		Camera.main.GetComponent<MouseLook>().enabled = false;          //Disables movement of the camera direction
	}

	private void EnableMouseLook()
	{
		Camera.main.GetComponent<MouseLook>().enabled = true;          //Enables movement of the camera direction
	}

	private void DisableCameraControl()
	{
		Camera.main.GetComponent<CameraControl>().enabled = false;          //Disables movement of the camera
	}

	private void EnableCameraControl()
	{
		Camera.main.GetComponent<CameraControl>().enabled = true;          //Enables movement of the camera
	}

    public void startGame()
    {
		btnSound.Play ();                   //Plays sound effect when button is clicked
		SceneManager.LoadScene(1);          //Starts the game by loading the starmap phase
    }

    public void helpMenu()
    {
		btnSound.Play ();                   //Plays button click sound effect
		SceneManager.LoadScene(7);          //Loads the scene cotaining the help information
    }

    public void mainMenu()
    {
		btnSound.Play ();                   //Plays button click sound effect
		SceneManager.LoadScene(0);          //Loads the main menu
    }



	public void enterSystem()
	{
        //Update Solar Buttons
        EnterSolar.SetActive(false);
        //ExitSolar.SetActive(true);

        SceneHandler.instance.changeScene(4);
	}



    public void exitSystem()
    {
        //Update Solar Buttons
        EnterSolar.SetActive(true);
        //ExitSolar.SetActive(false);

        //Terminate StellarGen
        GameObject.FindGameObjectWithTag("StellarGenController").GetComponent<StellarGen.StellarGenController>().Terminate();

        SceneHandler.instance.changeScene(1);
    }



    public void developOn()
    {
		DeveloperMenu.SetActive(true);
    }



	//public void OnGUI()
	//{
		//GUI.Label(new Rect(10, 10, 200, 30), ":: Developer Mode on ::");
	//}
}
