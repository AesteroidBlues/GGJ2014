using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public abstract class Player : MonoBehaviour {

    public int id;
    protected bool isMuderer;
    public Door nearestDoor;
    public Room currentRoom;

    protected abstract void OnPressX();
    protected abstract void OnPressA();

    // Use this for initialization
    void Start () {
        
    }

    void OpenDoor() {
        if ( nearestDoor )
            nearestDoor.open();
    }

    public void SetMurderer( bool murderer ) {
        this.isMuderer = murderer;
    }

    protected PlayerIndex GetIndex( int id ) {
        switch ( id ) {
            case 1: return PlayerIndex.One;
            case 2: return PlayerIndex.Two;
            case 3: return PlayerIndex.Three;
            case 4: return PlayerIndex.Four;
            default: return PlayerIndex.One;
        }
    }
}
