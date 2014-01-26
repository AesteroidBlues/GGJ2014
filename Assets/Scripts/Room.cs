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
        if (keyObjectsInRoom > 0)
        {
            MainDoor main = GameObject.FindGameObjectWithTag("MainDoor").GetComponent<MainDoor>();
            if (main != null)
            {
                main.FoundKeyObject();
                keyObjectsInRoom--;
            }
            else
                Debug.LogWarning("maindoor not set");
        }
    }

    
    
    public void Trap()
    {
        Debug.Log( "Trapped" );
        int x = Random.Range(0, 1);
        DetonationDelay = x / 10f;
        triggered = false;
        hasBomb = true;
    }

    public void TriggerBomb()
    {

        if (hasBomb && !triggered)
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
