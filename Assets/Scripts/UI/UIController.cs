using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject screenWellcome;
    public GameObject screenOptions;
    public GameObject UIScreens;
    public GameObject UIInGame;
   

    private GameObject currentScreen;

	// Use this for initialization
	void Start () {
        currentScreen = screenWellcome;

    }

    public void ShowOptionsScreen ()
    {

        screenWellcome.SetActive(false);
        screenOptions.SetActive(true);
    }

    public void ShowWellcomeScreen ()
    {
        screenWellcome.SetActive(true);
        screenOptions.SetActive(false);
    }

    public void StartGame ()
    {
        CameraController.isAutoMode = false;
        UIScreens.SetActive(false);
        UIInGame.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

   

}
