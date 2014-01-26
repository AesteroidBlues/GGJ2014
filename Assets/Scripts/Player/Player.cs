using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public abstract class Player : MonoBehaviour {

    public int id;
    protected bool isMuderer;
    public Door nearestDoor;
    public Room currentRoom;

    public GameObject ActionAnim;
    public float ActionAnimSpeed = 1.0f;

    protected abstract void OnPressX();
    protected void OnPressA()
    {
    }

    protected abstract void OnReleaseX();
    protected void OnReleaseA()
    {
        OpenDoor();
    }

    bool xPressed = false;
    bool aPressed = false;

    // Use this for initialization
    void Start () {

        ActionAnim.renderer.gameObject.SetActive(false);
    }

    void Update() {
        if (XInputManager.GetXButton(GetIndex()) && !xPressed)
        {
            xPressed = true;
            OnPressX();
        }
        else if (!XInputManager.GetXButton(GetIndex()) && xPressed)
        {
            xPressed = false;
            OnReleaseX();
        }
        if (XInputManager.GetAButton(GetIndex()) && !aPressed)
        {
            aPressed = true;
            OnPressA();
        }
        else if (!XInputManager.GetAButton(GetIndex()) && aPressed)
        {
            aPressed = false;
            OnReleaseA();
        }
    }

    void OpenDoor() {
        if ( nearestDoor != null)
            nearestDoor.open();
    }

    public void SetMurderer( bool murderer ) {
        this.isMuderer = murderer;
    }

    public PlayerIndex GetIndex() {
        switch ( this.id ) {
            case 1: return PlayerIndex.One;
            case 2: return PlayerIndex.Two;
            case 3: return PlayerIndex.Three;
            case 4: return PlayerIndex.Four;
            default: return PlayerIndex.One;
        }
    }
}
