using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int id;
    public Door NearestDoor;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //TODO pushing a logic
	}

    void OpenDoor()
    {
        if (NearestDoor)
            NearestDoor.open();
    }

    
}
