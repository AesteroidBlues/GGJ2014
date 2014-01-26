using UnityEngine;
using System.Collections;

public class MainDoor : MonoBehaviour {

	// Use this for initialization

    public int NumOfObjectsToFind = 6;
    private int ObjectsFound = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(NumOfObjectsToFind == ObjectsFound)
        {
            OpenMainDoor();
        }
	}

    private void OpenMainDoor()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        foreach (Transform t in transform)
        {
            if (t.tag == "OpenDoor")
                t.gameObject.SetActive(true);
            if (t.tag == "ClosedDoor")
                t.gameObject.SetActive(false);
        }

    }

    public void FoundKeyObject()
    {
        ObjectsFound++;
    }
}
