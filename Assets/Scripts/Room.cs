using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour {

    // Use this for initialization

    private List<Player> Occupants = new List<Player>();
    private bool hasBomb;

    private float DetonationDelay = 0.0f;
    private bool triggered;

    private int keyObjectsInRoom = 1;

    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {


            Player p = collider.gameObject.GetComponent<Player>();
            if (!Occupants.Contains(p))
                Occupants.Add(p);
            p.currentRoom = this;
            TriggerBomb();

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.LogWarning( "leaving" );
        if (collider.tag == "Player")
        {
            Player p = collider.gameObject.GetComponent<Player>();


            Occupants.Remove(p);
            if (p.GetType() == typeof(Murderer) && Occupants.Count > 0)
            {
                TriggerBomb();
            }
            p.currentRoom = null;
        }
    }

    public bool Search()
    {
        Debug.Log( "Searched" );
        if (keyObjectsInRoom > 0)
        {
            MainDoor main = GameObject.FindGameObjectWithTag("MainDoor").GetComponent<MainDoor>();
            if (main != null)
            {
                main.FoundKeyObject();
                keyObjectsInRoom--;
                return true;
                
            }
            else
                Debug.LogWarning("maindoor not set");
        }
        return false;
    }

    
    
    public bool Trap()
    {
        Debug.Log( "Trapped" );
        int x = Random.Range(1, 5);
        DetonationDelay = x / 10f;

        GameObject [] rooms = GameObject.FindGameObjectsWithTag("room");
        foreach(GameObject g in rooms)
        {
            g.GetComponent<Room>().hasBomb = false;
        }

        triggered = false;
        hasBomb = true;

        return keyObjectsInRoom > 0;
    }

    public void TriggerBomb()
    {
        bool containsMurderer = false;

        foreach (Player p in Occupants)
            if (p.GetType() == typeof(Murderer))
                containsMurderer = true;

        if (hasBomb && !triggered && !containsMurderer)
        {
            Debug.Log("bomb triggered");
            triggered = true;
            Invoke("Detonate", DetonationDelay);
        }   
    }

    private void Detonate()
    {
        foreach (Player p in Occupants)
            p.Kill();
    }


}
