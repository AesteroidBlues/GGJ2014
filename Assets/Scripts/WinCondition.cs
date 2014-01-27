﻿using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

    // Use this for initialization
    private GameManager gameManager;
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    
    // Update is called once per frame
    void Update () {
        if ( gameManager.PlayersKilled >= 3 ) {
            gameManager.MurdererWon();
            return;
        } else if ( gameManager.PlayersEscaped >= 3 ) {
            gameManager.SurvivorsWon();
            return;
        } else if( (gameManager.PlayersKilled + gameManager.PlayersEscaped ) >= 3 ) {
            gameManager.AmbiguousWin();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            Player p = collider.gameObject.GetComponent<Player>();
            if (p.GetType() == typeof(Survivor))
            {
                gameManager.EscapePlayer(p);
            }

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        
        
    }
}
