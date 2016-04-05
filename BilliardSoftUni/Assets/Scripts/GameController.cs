using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Balls;

    internal bool gamePaused;
    internal Queue<string> pottedBalls;
    internal int currentTurnPlayerId;

    private string[] players; // ["stripeBall", "solidBall"]
    private bool isFirstTurn;
    private bool shouldChangeTurn;
    private bool pottedSomethingThisTurn;
    private bool isFirstBall;
    private bool changedTurn;

    void Start()
    {
        gamePaused = true;

        pottedBalls = new Queue<string>();

        players = new string[2];
        currentTurnPlayerId = 0;

        isFirstTurn = true;
        shouldChangeTurn = false;
        pottedSomethingThisTurn = true;
        isFirstBall = true;
        changedTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        var allBalls = new List<GameObject>();
        for (int i = 0; i < Balls.transform.childCount; i++)
        {
            var currentBall = Balls.transform.GetChild(i).gameObject;

            if (currentBall.activeSelf)
            {
                allBalls.Add(currentBall);
            }
            else
            {
                UIPlayers.instance.SelectBall(currentBall.name);
            }
        }

        if (allBalls.All(a => a.GetComponent<Rigidbody>().velocity == Vector3.zero))
        {
            if (!string.IsNullOrEmpty(players[0]))
            {
                isFirstTurn = false;
            }

            if (!changedTurn)
            {
                if (!pottedSomethingThisTurn)
                {
                    ChangeTurn();
                }

                if (shouldChangeTurn)
                {
                    ChangeTurn();
                }

                changedTurn = true;
            }

            shouldChangeTurn = false;
            pottedSomethingThisTurn = false;
            isFirstBall = true;
        }
        else
        {
            changedTurn = false;
        }

        var currentBallTag = "";
        if (pottedBalls.Count > 0)
        {
            currentBallTag = pottedBalls.Dequeue();
        }

        if (!string.IsNullOrEmpty(currentBallTag))
        {
            pottedSomethingThisTurn = true;

            if (isFirstTurn)
            {
                if (currentBallTag == "whiteBall")
                {
                    shouldChangeTurn = true;
                }
                else
                {
                    UIPlayers.instance.SetBallType(currentTurnPlayerId, currentBallTag == "solidBall" ? 0 : 1);
                    UIPlayers.instance.SetBallType(currentTurnPlayerId == 1 ? 0 : 1,
                        currentBallTag == "solidBall" ? 1 : 0);

                    players[currentTurnPlayerId] = currentBallTag;

                    var otherPlId = currentTurnPlayerId == 0 ? 1 : 0;
                    var otherPlBallsType = currentBallTag == "stripeBall" ? "solidBall" : "stripeBall";
                    players[otherPlId] = otherPlBallsType;
                }
            }
            else // is not first turn
            {
                if (currentBallTag == "blackBall")
                {
                    var currentPlHaveMoreBalls = allBalls.Any(a => a.tag == players[currentTurnPlayerId]);
                    Debug.Log(players[currentTurnPlayerId]);

                    if (currentPlHaveMoreBalls)
                    {
                        UIController.Instance.GameFinished(currentTurnPlayerId, false);

                        Debug.Log("Game Over!");
                    }
                    else
                    {
                        UIController.Instance.GameFinished(currentTurnPlayerId, true);

                        Debug.Log(currentTurnPlayerId + " Won!");
                    }
                }
                else if (currentBallTag == "whiteBall")
                {
                    shouldChangeTurn = true;
                }
                else // potted stripe or solid ball
                {
                    if (isFirstBall)
                    {
                        if (currentBallTag != players[currentTurnPlayerId]) // potted correct ball
                        {
                            shouldChangeTurn = true;
                        }

                        isFirstBall = false;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIController.Instance.ShowWellcomeScreen();
        }
    }

    void ChangeTurn()
    {
        currentTurnPlayerId = currentTurnPlayerId == 0 ? 1 : 0;
        Debug.Log("Turn changed!");
        UIController.Instance.ChangePlayer();
    }
}
