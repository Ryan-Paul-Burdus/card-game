using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isPlayer1Turn;
    public GameObject player1;
    public GameObject player2;

    Player player1Script;
    AIPlayer player2Script;

    private void Start()
    {
        player1Script = player1.GetComponent<Player>();
        player2Script = player2.GetComponent<AIPlayer>();
        isPlayer1Turn = (Random.value > 0.5f);
        if (isPlayer1Turn)
        {
            player1Script.turnNumber = 1;
        }
        else
        {
            player2Script.turnNumber = 1;
        }
    }

    public void EndTurn()
    {
        if (isPlayer1Turn)//player 1 has pressed end turn
        {
            player2Script.IncrementTurnNo();
            isPlayer1Turn = false;
        }
        else//player 2 has pressed end turn
        {
            player1Script.IncrementTurnNo();
            isPlayer1Turn = true;
        }
    }
}
