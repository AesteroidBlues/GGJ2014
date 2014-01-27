using UnityEngine;
using System.Collections;

public class MainDoor : MonoBehaviour {

    // Use this for initialization

    public int NumOfObjectsToFind = 6;
    private int ObjectsFound = 0;
    public AudioClip MainDoorOpen;

    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        if(NumOfObjectsToFind == ObjectsFound)
        {
            OpenMainDoor();
        }
    }

    bool opened = false;

    private void OpenMainDoor()
    {
        if ( !opened ) {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            opened = true;
            transform.GetChild( 0 ).GetComponent<Animator>().SetTrigger( "OpenDoor" );
            transform.GetChild( 1 ).GetComponent<Animator>().SetTrigger( "OpenDoor" );
            Invoke( "FinishOpen", 0.3f );
            SoundManager.Instance.PlaySound( MainDoorOpen );
        }
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
