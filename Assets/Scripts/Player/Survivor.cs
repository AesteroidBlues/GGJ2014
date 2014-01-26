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
            Debug.Log( "X Pressed" );
            ActionAnim.renderer.enabled = true;
            ActionAnim.GetComponent<Animator>().speed = ( ActionAnimSpeed / 2 );
            ActionAnim.GetComponent<Animator>().SetBool("PerformAction", true);
            Invoke("SearchRoom", ActionAnimSpeed);
        }
    }


    protected override void OnReleaseX()
    {
        Debug.Log( "X Released" );
        CancelInvoke("SearchRoom");
        ActionAnim.renderer.enabled = false;
        ActionAnim.GetComponent<Animator>().SetBool("PerformAction", false);
    }

    private void SearchRoom()
    {
        if (currentRoom != null)
        {
            currentRoom.Search();
        }
    }
}
