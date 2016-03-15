using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject screenWellcome;
    public GameObject screenOptions;
    public GameObject UIScreens;
    public GameObject UIInGame;
    public Text playersTurn;

    private GameObject currentScreen;
    private Animator playerTurnAnimation;
    

	// Use this for initialization
	void Start () {
        currentScreen = screenWellcome;
        playerTurnAnimation = playersTurn.gameObject.GetComponent<Animator>();

        playersTurn.gameObject.SetActive(false);

        //PlayersTurn(2);
        //StartCoroutine(PlayersTurn(2));

        //StartCoroutine(GameFinished("David"));
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

    public IEnumerator PlayersTurn (int playerNum)
    {
        playersTurn.text = "Player's " + playerNum + " Turn";
        playersTurn.gameObject.SetActive(true);
        playerTurnAnimation.SetBool("IsHide", false);

        yield return new WaitForSeconds(3);
        playerTurnAnimation.SetBool("IsHide", true);
    }

    public IEnumerator GameFinished (string playerName)
    {
        playersTurn.text = playerName +" WON";
        playersTurn.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);
        playerTurnAnimation.SetBool("IsHide", true);

    }

}
