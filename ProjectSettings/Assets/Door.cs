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

    void OnCollisionEnter(Collision c)
    {
        foreach (ContactPoint contact in c.contacts)
        {
            if (c.collider.tag == "Player")
            {
                Player p = c.collider.gameObject.GetComponent<Player>();
                p.SetNearestDoor(this);

            }
        }
    }

    void OnCollisionExit(Collision c)
    {
        foreach (ContactPoint contact in c.contacts)
        {
            if (c.collider.tag == "Player")
            {
                Player p = c.collider.gameObject.GetComponent<Player>();
                p.ExitDoorArea(this);

            }
        }
    }

}
