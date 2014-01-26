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
            currentRoom.Search();

            ActionAnim.renderer.gameObject.SetActive(true);
            ActionAnim.GetComponent<Animator>().speed = ActionAnimSpeed;
            ActionAnim.GetComponent<Animator>().SetBool("PerformAction", true);
            Invoke("OnReleaseX", ActionAnimSpeed);
        }
    }


    protected override void OnReleaseX()
    {
        CancelInvoke("OnReleaseX");
        ActionAnim.renderer.gameObject.SetActive(false);
        ActionAnim.GetComponent<Animator>().SetBool("PerformAction", false);
    }
}
