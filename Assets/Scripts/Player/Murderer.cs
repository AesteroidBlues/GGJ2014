using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Murderer : Player {

    // Use this for initialization
    void Start () {

    }
    
    // Update is called once per frame
    void Update () {
        if ( XInputManager.GetXButton( GetIndex() ) ) {
            Debug.Log( "ID: " + id + " pressed X" );
            OnPressX();
        }
    }

    protected override void OnPressX() {
        GamePad.SetVibration( GetIndex(), 1f, 1f );
        currentRoom.Trap();

        ActionAnim.renderer.gameObject.SetActive(true);
        ActionAnim.GetComponent<Animator>().speed = ActionAnimSpeed;
        ActionAnim.GetComponent<Animator>().SetBool("PerformAction", true);
        Invoke("OnReleaseX", ActionAnimSpeed);
    }

    protected override void OnPressA()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnReleaseX()
    {
        CancelInvoke();
        ActionAnim.renderer.gameObject.SetActive(false);
        ActionAnim.GetComponent<Animator>().SetBool("PerformAction", false);
    }
}
