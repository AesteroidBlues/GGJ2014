﻿using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour {

	// Use this for initialization

    private List<Player> Occupants = new List<Player>();
    private bool hasBomb;

    public float DetonationDelay = 0.0f;
    private bool triggered;

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
                p.currentRoom = this;

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
                p.currentRoom = null;

            }
        }
    }

    public void Search()
    {

    }

    
    
    public void Trap()
    {
        int x = Random.Range(0, 1);
        DetonationDelay = x / 10f;
        triggered = false;
        hasBomb = true;
    }

    public void Trigger()
    {
        if (hasBomb && !triggered)
        {
            triggered = true;
            Invoke("Detonate", DetonationDelay);
        }   
    }

    private void Detonate()
    {

    }


}