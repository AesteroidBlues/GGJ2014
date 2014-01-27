using UnityEngine;
using System.Collections.Generic;

public class CameraGUI : MonoBehaviour {
    public GUIStyle style;
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    void OnGUI() {
        Queue<string> playersKilled = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameManager>().playersKilled;
        Queue<string> playersEscaped = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameManager>().playersEscaped;
        List<string> survivorsEscaped = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameManager>().survivorsEscaped;

        bool survivorsWon = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameManager>().survivorsWon;
        bool murdererWon = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameManager>().murdererWon;
        bool ambiguousWin = GameObject.FindGameObjectWithTag( "GameController" ).GetComponent<GameManager>().ambiguousWin;

        Debug.LogWarning( survivorsWon );

        GUI.BeginGroup( new Rect( Screen.width / 2 - 200, Screen.height / 2 - 50, 600, 400 ) );
        GUI.contentColor = Color.white;
        GUI.color = Color.white;
        int y = 0;
        foreach ( string killed in playersKilled ) {
            GUI.Label( new Rect( 0, y, 400, 100 ), killed + " was killed!", style );
            y += 35;
        }
        foreach ( string escaped in playersEscaped ) {
            GUI.Label( new Rect( 0, y, 400, 100 ), escaped + " escaped the house!", style );
            y += 35;
        }
        if ( murdererWon ) {
            Debug.LogWarning( "Murderer Won!" );
            GUI.Label( new Rect( 0, y, 400, 100 ), "MURDERER WON!", style );
            y += 35;
        }
        if ( survivorsWon ) {
            Debug.LogWarning( "Survivors Won!" );
            GUI.Label( new Rect( 0, y, 400, 100 ), "SURVIVORS WON!", style );
            y += 35;
        } if ( ambiguousWin ) {
            string survivors = "";
            foreach ( string survivor in survivorsEscaped ) {
                survivors = survivors + survivor + ", ";
            }
            survivors = survivors.Substring( 0, survivors.Length - 2 );
            GUI.Label( new Rect( 0, y, 400, 100 ), survivors + " escaped the murderer!", style );
            y += 35;
        }

        GUI.EndGroup();
    }
}
