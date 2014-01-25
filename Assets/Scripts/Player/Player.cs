using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {

    public int id;
    protected bool isMuderer;

    protected abstract void OnPressX();

    // Use this for initialization
    void Start () {
        
    }

    public void SetMurderer( bool murderer ) {
        this.isMuderer = murderer;
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
