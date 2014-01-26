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

            ActionAnim.renderer.gameObject.SetActive(true);
            ActionAnim.GetComponent<Animator>().speed = ActionAnimSpeed;
            ActionAnim.GetComponent<Animator>().SetBool("PerformAction", true);
            Invoke("SearchRoom", ActionAnimSpeed);
        }
    }


    protected override void OnReleaseX()
    {
        CancelInvoke("SearchRoom");
        ActionAnim.renderer.gameObject.SetActive(false);
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
