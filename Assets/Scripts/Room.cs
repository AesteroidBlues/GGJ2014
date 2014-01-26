using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour {

    // Use this for initialization

    private List<Player> Occupants = new List<Player>();
    private bool hasBomb;

    private float DetonationDelay = 0.0f;
    private bool triggered;

    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log( "Room found player " + collider.gameObject.name );
            Player p = collider.gameObject.GetComponent<Player>();
            if (!Occupants.Contains(p))
                Occupants.Add(p);
            p.currentRoom = this;

        }
    }

    void OnTriggerExit2D( Collider2D collider )
    {
        if (collider.tag == "Player")
        {
            Player p = collider.gameObject.GetComponent<Player>();
            Occupants.Remove(p);
            p.currentRoom = null;

        }
    }

    public void Search()
    {
        Debug.Log( "Searched" );
    }

    
    
    public void Trap()
    {
        Debug.Log( "Trapped" );
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
