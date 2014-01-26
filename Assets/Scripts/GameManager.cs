﻿using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public ArrayList players;
    public int NumberOfPlayers = 4;
    private System.Random random = new System.Random(System.DateTime.Now.Millisecond);

    private bool murdererChosen = false;

    // Use this for initialization
    void Start () {
        GameObject[] spawntags = GameObject.FindGameObjectsWithTag("Respawn");
        shuffle( spawntags, NumberOfPlayers );
        players = new ArrayList();
        for (int id = 0; id < NumberOfPlayers; ++id)
        {
            GameObject newPlayer = ( GameObject ) Instantiate( playerPrefab, 
                                                               spawntags[id].transform.position,
                                                               Quaternion.identity );
            Type t = GetPlayerType( id );
            Player component = ( Player ) newPlayer.AddComponent( t.ToString() );
            component.id = id + 1;
            players.Add( newPlayer );
        }
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    // Shuffles randomly NumShuffles times. The front NumShuffles in the array
    // are the shuffled elements. All objects in the array stay in the array, but
    // their order will be different. The advantage is no new memory is required, so if
    // persisting order doesn't matter, this is optimal.
    private void shuffle(GameObject[] arr, int NumShuffles)
    {
        for (int i = 0; i < NumShuffles; i++)
        {
            int r = random.Next(0, arr.Length);
            // swap
            var temp = arr[i];
            arr[i] = arr[r];
            arr[r] = temp;
        }
    }

    private Type GetPlayerType( int id ) {
        // Randomly assign murderer status to one of the players
        if ( !murdererChosen ) {
            if ( id < NumberOfPlayers - 1 ) {
                if ( random.Next( 0, 100 ) < 25 ) {
                    murdererChosen = true;
                    return typeof( Murderer );
                } else {
                    return typeof( Survivor );
                }
            } else {
                return typeof( Murderer );
            }
        } else {
            return typeof( Survivor );
        }
    }
}
