using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Murderer : Player {

    // Use this for initialization
    void Start () {
        System.Random r = new System.Random();
        InvokeRepeating( "RightBeat", r.Next(2, 4), r.Next(10, 16) );

    }
    
   
    protected override void OnPressX() {
        if (currentRoom != null)
        {
            currentRoom.Trap();
            ActionAnim.renderer.gameObject.SetActive(true);
            ActionAnim.GetComponent<Animator>().speed = ActionAnimSpeed;
            ActionAnim.GetComponent<Animator>().SetBool("PerformAction", true);
            Invoke("OnReleaseX", ActionAnimSpeed);
        }
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
    }


    protected override void OnReleaseX()
    {
        CancelInvoke("OnReleaseX");
        ActionAnim.renderer.gameObject.SetActive(false);
        ActionAnim.GetComponent<Animator>().SetBool("PerformAction", false);
    }
}
