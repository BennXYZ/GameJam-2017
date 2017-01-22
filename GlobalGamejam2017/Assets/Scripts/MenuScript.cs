using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class MenuScript : MonoBehaviour
{
    //TODO: Before finish delete all debug comments!

    /// <summary>
    /// Enum of all menu states.
    /// </summary>
    public enum MenuStates
    {
        Main,
        Player,
        Help,
        Credits,
        Exit
    }

    #region variables

    // Variable for define current state.
    public MenuStates currentState;

    public GamePad gamePad;

    // Menu panel objects as GameObjects.
    public GameObject mainMenu;
    public GameObject playerMenu;
    public GameObject helpMenu;
    public GameObject creditsMenu;
    //TODO: Uncomment this if application exit in MenuState.Exit works!
    //public GameObject exitMenu;

    // Player menu toggles
    public bool isSelected;
    public Toggle isOnePlayer;
    public Toggle isTwoPlayer;
    public Toggle isThreePlayer;

    #endregion
    
    
    /// <summary>
    /// Initialize any variables or game states before the game starts.
    /// Is called only once during the lifetime of the script instance.
    /// </summary>
    void Awake()
    {
        // Always sets first state to main menu
        currentState = MenuStates.Main;
    }


    /// <summary>
    /// Update is called every frame.
    /// Checks menu state every frame.
    /// </summary>
    void Update()
    {
        

        // Checks current menu state
        switch (currentState)
        {
                case MenuStates.Main:
                    // Sets active gameobject for main menu
                    mainMenu.SetActive(true);
                    playerMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                    break;

                case MenuStates.Player:
                    // Sets active gameobject for player menu
                    playerMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                    break;

                case MenuStates.Help:
                    // Sets active gameobject for options menu
                    helpMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    playerMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                break;

                case MenuStates.Credits:
                    // Sets active gameobject for options menu
                    creditsMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    playerMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                break;

            case MenuStates.Exit:
                //Exits game
                //mainMenu.SetActive(false);
                //playerMenu.SetActive(false);
                //optionsMenu.SetActive(false);
                //helpMenu.SetActive(false);
                //creditsMenu.SetActive(false);
                //exitMenu.SetActive(true);
                break;
        }
    }

    #region Button OnClick

    /// <summary>
    /// Interaction with start button.
    /// Changes current state to playerMenu.
    /// </summary>
    public void OnStartGame()
    {
        // Log activity
        Debug.Log("You pressed start game!");

        //TODO: If LoadScene is being used delete this.
        currentState = MenuStates.Player;

        //TODO: Uncomment this if player selection after start is not needed and is implemented else.
        // Add load level for new scene here.
        // SceneManager.LoadScene("GameScreen");
    }

    /// <summary>
    /// Interaction with play button.
    /// Loads game scene.
    /// </summary>
    public void OnPlayGame()
    {
        // Log activity
        Debug.Log("You pressed Let's play!");

        // Check active toggle through function.
        ActiveToggle();

        // Add load level for new scene here.
        if (isSelected == true)
        {
            SceneManager.LoadScene("Main_Game_V1");
        }

        else
        {
            // Log activity
            Debug.Log("SELECT ONE OPTION!!!");

            //TODO: Add function to deactivate button visualy maybe?
        }
    }


    /// <summary>
    /// Interaction with back button.
    /// Changes current state to mainMenu.
    /// Back button is in every submenue except on "Start" and "Exit".
    /// </summary>
    public void OnBackToMenu()
    {
        // Log activity
        Debug.Log("Go back to main menu.");

        // Change menu state
        currentState = MenuStates.Main;
    }

    /// <summary>
    /// Interaction with help button.
    /// Changes current state to helpMenu.
    /// </summary>
    public void OnHelp()
    {
        // Log activity
        Debug.Log("Help button clicked.");

        // Change menu state
        currentState = MenuStates.Help;
    }

    public void OnCredits()
    {
        // Log activity
        Debug.Log("Credits button clicked.");

        // Change menu state
        currentState = MenuStates.Credits;
    }

    public void OnExit()
    {
        // Log activity
        Debug.Log("Ext button clicked.");

        Application.Quit();

        //TODO: Menu state or just Application.Quit() ??
        // Change menu state
        //currentState = MenuStates.Exit;
    }

    #endregion

    #region Player menu toggles

    /// <summary>
    /// Checks which toggle is active.
    /// </summary>
    public void ActiveToggle()
    {
        if (isOnePlayer.isOn)
        {
            // Log activity
            Debug.Log("One player selected!");
            isSelected = true;
        }
        
        else if (isTwoPlayer.isOn)
        {
            // Log activity
            Debug.Log("Two players selected!");
            isSelected = true;
        }

        else if (isThreePlayer.isOn)
        {
            // Log activity
            Debug.Log("Three players selected!");
            isSelected = true;
        }
        else
        {
            // Log activity
            Debug.Log("No option is selected...");
            isSelected = false;
        }
    }

    #endregion

    // If needed for event handling
    #region EventHandler

    //NOTE: ClickHandler maybe for exit application?! -> Just mouse ...
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        Application.Quit();
    //    }
    //}

    #endregion
}