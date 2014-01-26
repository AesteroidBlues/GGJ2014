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
        transform.GetChild( 0 ).GetComponent<Animator>().SetTrigger( "OpenDoor" );
        transform.GetChild( 1 ).GetComponent<Animator>().SetTrigger( "OpenDoor" );
        Invoke( "FinishOpen", 0.3f );
    }

    private void FinishOpen() {
        transform.GetChild( 0 ).GetComponent<Animator>().speed = 0;
        transform.GetChild( 1 ).GetComponent<Animator>().speed = 0;
    }

    public void FoundKeyObject()
    {
        ObjectsFound++;
    }
}
