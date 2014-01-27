using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using XInputDotNetPure;

public class GameManager : MonoBehaviour {

    public ArrayList players;
    public int NumberOfPlayers = 4;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public GameObject bloodstain;

    private System.Random random = new System.Random(System.DateTime.Now.Millisecond);

    private bool murdererChosen = false;

    public Queue<string> playersEscaped;
    public Queue<string> playersKilled;

    // Use this for initialization
    void Start () {
        GameObject[] spawntags = GameObject.FindGameObjectsWithTag("Respawn");
        shuffle( spawntags, NumberOfPlayers );
        players = new ArrayList();
        for (int id = 0; id < NumberOfPlayers; ++id)
        {
            GameObject newPlayer = ( GameObject ) Instantiate( GetPlayerObject( id ), 
                                                               spawntags[id].transform.position,
                                                               Quaternion.identity );
            Type t = GetPlayerType( id );
            Player component = ( Player ) newPlayer.AddComponent( t.ToString() );
            newPlayer.tag = "Player";
            component.id = id + 1;
            players.Add( newPlayer );
        }
        playersKilled = new Queue<string>();
        playersEscaped = new Queue<string>();
        survivorsEscaped = new List<string>();
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

    private GameObject GetPlayerObject( int id ) {
        switch ( id ) {
            case 0: return p1;
            case 1: return p2;
            case 2: return p3;
            case 3: return p4;
            default: return p1;
        }
    }

    public int PlayersKilled = 0;
    public int PlayersEscaped = 0;
    
    public bool murdererWon;
    public bool survivorsWon;
    public bool ambiguousWin;

    public List<string> survivorsEscaped;

    public void KillPlayer( Player p ) {
        PlayersKilled++;
        playersKilled.Enqueue( "Player " + p.id );
        GameObject.Instantiate( bloodstain, p.gameObject.transform.position, Quaternion.identity );
        Destroy( p.gameObject, 0.1f );
        Invoke( "ClearKilledPlayer", 2.5f );
    }

    public void EscapePlayer( Player p ) {
        PlayersEscaped++;
        playersEscaped.Enqueue( "Player " + p.id );
        survivorsEscaped.Add( "Player " + p.id );
        Destroy( p.gameObject, 0.1f );
        Invoke( "ClearEscapedPlayer", 2.5f );
    }

    void ClearKilledPlayer() {
        if ( playersKilled.Count > 0 ) {
            playersKilled.Dequeue();
        }
    }

    void ClearEscapedPlayer() {
        if ( playersEscaped.Count > 0 ) {
            playersEscaped.Dequeue();
        }
    }

    public void MurdererWon()
    {
        murdererWon = true;
        Invoke( "ResetScene", 4f );
    }

    public void SurvivorsWon()
    {
        survivorsWon = true;
        Invoke( "ResetScene", 4f );
    }

    public void AmbiguousWin() {
        ambiguousWin = true;
        Invoke( "ResetScene", 4f );
    }

    private void ResetScene() {
        GamePad.SetVibration( PlayerIndex.One, 0f, 0f );
        GamePad.SetVibration( PlayerIndex.Two, 0f, 0f );
        GamePad.SetVibration( PlayerIndex.Three, 0f, 0f );
        GamePad.SetVibration( PlayerIndex.Four, 0f, 0f );

        Application.LoadLevel( Application.loadedLevel );
    }
}
