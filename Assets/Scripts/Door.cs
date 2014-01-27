using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }	
    
    // Update is called once per frame
    void Update () {

    }

    bool opened = false;
    public void open()
    {
        if (!opened)
        {
            Invoke("PreClose", 1.5f);
            transform.GetChild( 0 ).GetComponent<Animator>().speed = 1;
            transform.GetChild( 0 ).GetComponent<Animator>().SetTrigger( "OpenDoor" );
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            SoundManager.Instance.PlaySound(SoundManager.Instance.Clips[0]);
            opened = true;
            Invoke( "FinishOpen", 0.3f );
        }
    }

    private void FinishOpen() {
        transform.GetChild( 0 ).GetComponent<Animator>().speed = 0;
    }

    private void PreClose() {
        transform.GetChild( 0 ).GetComponent<Animator>().speed = -1;
        SoundManager.Instance.PlaySound( SoundManager.Instance.Clips[1] );
        Invoke( "close", 0.3f );
    }

    private void close()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        transform.GetChild( 0 ).GetComponent<Animator>().SetTrigger( "CloseDoor" );
        CancelInvoke("close");
        opened = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            Player p = collider.gameObject.GetComponent<Player>();
            p.nearestDoor = this;

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Player p = collider.gameObject.GetComponent<Player>();
            p.nearestDoor = null;

        }
    }

}
