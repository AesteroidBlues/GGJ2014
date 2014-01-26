using UnityEngine;
using System.Collections;

public class Survivor : Player {

    // Use this for initialization
    void Start () {
        base.Init();
    }
   

    protected override void OnPressX() {
        if (currentRoom != null)
        {
            ActionAnim.renderer.enabled = true;
            ActionAnim.GetComponent<Animator>().speed = ( ActionAnimSpeed );
            ActionAnim.GetComponent<Animator>().SetBool("PerformAction", true);
            Invoke( "SearchRoom", ActionSpeed );
            CanMove = false;
        }
    }


    protected override void OnReleaseX()
    {

        CancelInvoke("SearchRoom");
        ActionAnim.renderer.enabled = false;
        ActionAnim.GetComponent<Animator>().SetBool("PerformAction", false);
        CanMove = true;
    }

    private void SearchRoom()
    {
        if ( currentRoom != null ) {
            bool success = currentRoom.Search();
            if ( success ) {
                ActionAnim.GetComponent<Animator>().SetTrigger( "Success" );
            } else {
                ActionAnim.GetComponent<Animator>().SetTrigger( "Fail" );
            }
            Invoke( "OnReleaseX", 0.19f );
        } else {
            Debug.LogWarning( "Current room is null" );
        }
    }
}
