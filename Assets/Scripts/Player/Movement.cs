using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public int speed = 3;
    
    // Update is called once per frame
    void Update () {
        int id = GetComponent<Player>().id;
        float h = Input.GetAxis( "L_XAxis_" + id );
        float v = Input.GetAxis( "L_YAxis_" + id );

        rigidbody2D.velocity = new Vector3( h * speed, -v * speed, 0 );
    }
}
