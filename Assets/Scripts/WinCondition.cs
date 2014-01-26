using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	// Use this for initialization
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
            if (p.GetType() == typeof(Survivor))
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().EscapePlayer(p);
            }

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        
        }
    }
}
