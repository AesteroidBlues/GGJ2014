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

        GUI.BeginGroup( new Rect( Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 400 ) );
        GUI.contentColor = Color.black;
        int y = 0;
        foreach ( string killed in playersKilled ) {
            GUI.Label( new Rect( 0, y, 400, 100 ), killed + " was killed!", style );
            y += 35;
        }
        foreach ( string escaped in playersEscaped ) {
            GUI.Label( new Rect( 0, y, 400, 100 ), escaped + " escaped the house!", style );
            y += 35;
        }
        GUI.EndGroup();
    }
}
