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
        gameObject.SetActive(false);
    }

    private void close()
    {
        gameObject.SetActive(true);

    }
    
    void OnCollisionEnter2D(Collision2D collider)
    {

        Debug.Log("entering");
        foreach (ContactPoint2D c in collider.contacts)
        {
            if (c.collider.tag == "Player")
            {
                Player p = c.collider.gameObject.GetComponent<Player>();
                p.nearestDoor = this;
                Debug.Log("setting neest door " + p);

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
