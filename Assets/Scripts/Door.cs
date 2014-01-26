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

    void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint c in collider.contacts)
        {
            if (c.thisCollider.tag == "Player")
            {
                Player p = c.thisCollider.gameObject.GetComponent<Player>();
                p.nearestDoor = this;
                Debug.Log("setting neest door " + p);

            }
        }
    }

    void OnCollisionExit(Collision contact)
    {
        foreach (ContactPoint c in contact.contacts)
        {
            if (c.thisCollider.tag == "Player")
            {
                Player p = c.thisCollider.gameObject.GetComponent<Player>();
                p.nearestDoor = null;

            }
        }
    }

}
