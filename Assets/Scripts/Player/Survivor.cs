using UnityEngine;
using System.Collections;

public class Survivor : Player {

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    protected override void OnPressX() {
        if (currentRoom)
        {
            currentRoom.Search();

            ActionAnim.renderer.gameObject.SetActive(true);
            ActionAnim.GetComponent<Animator>().speed = ActionAnimSpeed;
            ActionAnim.GetComponent<Animator>().SetBool("PerformAction", true);
            Invoke("OnReleaseX", ActionAnimSpeed);
        }
    }

    protected override void OnPressA(){
    }

    protected override void OnReleaseX()
    {
        CancelInvoke("OnReleaseX");
        ActionAnim.renderer.gameObject.SetActive(false);
        ActionAnim.GetComponent<Animator>().SetBool("PerformAction", false);
    }
}
