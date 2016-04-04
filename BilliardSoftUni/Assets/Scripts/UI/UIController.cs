using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public GameObject screenWellcome;
    public GameObject screenOptions;
    public GameObject UIScreens;
    public GameObject UIInGame;
    public Text playersTurn;

    private GameObject currentScreen;
    private Animator playerTurnAnimation;
    private int currentPlayer = 1;
    // Use this for initialization
    void Start()
    {
        Instance = this;
        currentScreen = screenWellcome;
        playerTurnAnimation = playersTurn.gameObject.GetComponent<Animator>();

        playersTurn.gameObject.SetActive(false);

        //PlayersTurn(2);
        //StartCoroutine(PlayersTurn(2));

        //StartCoroutine(GameFinished("David"));
    }

    public void ShowOptionsScreen()
    {
        screenWellcome.SetActive(false);
        screenOptions.SetActive(true);
    }

    public void ShowWellcomeScreen()
    {
        screenWellcome.SetActive(true);
        screenOptions.SetActive(false);
    }

    public void StartGame()
    {
        CameraController.isAutoMode = false;

        var playerFields = UIInGame.GetComponentsInChildren<Text>();

        UIScreens.SetActive(false);
        UIInGame.SetActive(true);


        StartCoroutine(PlayersTurn(1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public IEnumerator PlayersTurn(int playerNum)
    {
        Debug.Log("PlayersTurn");


        playersTurn.text = UIPlayers.instance.GetPlayerName(playerNum) + "'s Turn";
        playersTurn.gameObject.SetActive(true);
        playerTurnAnimation.SetBool("IsShow", true);


        yield return new WaitForSeconds(3);
        playerTurnAnimation.SetBool("IsShow", false);
    }

    public IEnumerator GameFinished(int playerId, bool won) // if won == false -> game over
    {
        if (won)
        {
            playersTurn.text = UIPlayers.instance.GetPlayerName(playerId) + " HAS WON";
        }
        else
        {
            playersTurn.text = UIPlayers.instance.GetPlayerName(playerId) + " HAS LOST";
        }
        
        playersTurn.gameObject.SetActive(true);
        playerTurnAnimation.SetBool("IsShow", true);

        yield return new WaitForSeconds(3);
        playerTurnAnimation.SetBool("IsShow", false);

    }

    public void ChangePlayer()
    {
        currentPlayer = currentPlayer == 0 ? 1 : 0;

        StartCoroutine(PlayersTurn(currentPlayer));
    }
}
