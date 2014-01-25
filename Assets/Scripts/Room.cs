using UnityEngine;
using System.Collections.Generic;

public class Floor : MonoBehaviour {

	// Use this for initialization

    private List<Player> Occupants = new List<Player>();
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint c in collider.contacts)
        {
            if (c.thisCollider.tag == "Player")
            {
                Player p = c.thisCollider.gameObject.GetComponent<Player>();
                if (!Occupants.Contains(p))
                    Occupants.Add(p);

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
                Occupants.Remove(p);

            }
        }
    }



}
