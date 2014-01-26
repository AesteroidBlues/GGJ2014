using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }	
    
    // Update is called once per frame
    void Update () {

    }

    public void open()
    {
        Invoke("close", 3f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        foreach(Transform t in transform)
        {
            Debug.Log( t );
            if(t.tag == "OpenDoor")
                t.gameObject.SetActive(true);
            if (t.tag == "ClosedDoor")
                t.gameObject.SetActive(false);
        }


    }

    private void close()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        foreach (Transform t in transform)
        {
            if (t.tag == "OpenDoor")
                t.gameObject.SetActive(false);
            if (t.tag == "ClosedDoor")
                t.gameObject.SetActive(true);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collider)
    {
        foreach (ContactPoint2D c in collider.contacts)
        {
            if (c.collider.tag == "Player")
            {
                Player p = c.collider.gameObject.GetComponent<Player>();
                p.nearestDoor = this;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        foreach (ContactPoint2D c in collider.contacts)
        {
            if (c.collider.tag == "Player")
            {
                Player p = c.collider.gameObject.GetComponent<Player>();
                p.nearestDoor = null;

            }
        }
    }

}
