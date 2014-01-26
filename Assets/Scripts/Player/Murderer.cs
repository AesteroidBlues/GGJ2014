using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Murderer : Player {

    System.Random r = new System.Random();

    // Use this for initialization
    void Start () {
        base.Init();
        InvokeRepeating( "RightBeat", r.Next(1, 2), r.Next(5, 7) );
    }

    private void RightBeat() {
        Debug.Log( "RightBeat Called" );
        GamePad.SetVibration( GetIndex(), 0f, 0.3f );
        Invoke( "LeftBeat", 0.15f );
    }

    private void LeftBeat() {
        GamePad.SetVibration( GetIndex(), 0.25f, 0f );
        Invoke( "EndBeat", 0.4f );
    }

    private void EndBeat() {
        GamePad.SetVibration( GetIndex(), 0f, 0f );
        switch ( GameObject.FindGameObjectsWithTag( "Player" ).Length ) {
            case 3: CancelInvoke( "RightBeat" ); InvokeRepeating( "RightBeat", 2, r.Next( 3, 4 ) ); break;
            case 2: CancelInvoke( "RightBeat" ); InvokeRepeating( "RightBeat", 0.6f, 0.6f ); break;
            default: break;
        }
    }


    protected override void OnPressX()
    {
        if (currentRoom != null)
        {
            ActionAnim.renderer.enabled = true;
            ActionAnim.GetComponent<Animator>().speed = ( ActionAnimSpeed );
            ActionAnim.GetComponent<Animator>().SetBool("PerformAction", true);
            Invoke( "TrapRoom", ActionSpeed );
        }
    }

    protected override void OnReleaseX()
    {
        CancelInvoke("TrapRoom");
        ActionAnim.renderer.enabled = false;
        ActionAnim.GetComponent<Animator>().SetBool("PerformAction", false);
    }

    private void TrapRoom()
    {
        if (currentRoom != null)
        {
            currentRoom.Trap();
            OnReleaseX();
        }
    }

    void OnApplicationQuit() {
        GamePad.SetVibration( GetIndex(), 0f, 0f );
    }
    
}
