using UnityEngine;
using System.Collections;

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
    
    // Update is called once per frame
    void Update () {
    
    }
}
