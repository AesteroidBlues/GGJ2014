using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Murderer : Player {

    // Use this for initialization
    void Start () {

    }
    
    // Update is called once per frame
    void Update () {
        if ( Input.GetButton( "X_" + id ) ) {
            Debug.Log( "ID: " + id + " pressed X" );
            OnPressX();
        }
    }

    protected override void OnPressX() {
        GamePad.SetVibration( GetIndex(id), 1f, 1f );
        currentRoom.Trap();
    }

    protected override void OnPressA()
    {
        throw new System.NotImplementedException();
    }
}
