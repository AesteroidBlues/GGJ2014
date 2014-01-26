using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public int speed = 3;
    public float animationSpeed = 0.8f;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {
        int id = GetComponent<Player>().id;
        float h = Input.GetAxis( "L_XAxis_" + id );
        float v = Input.GetAxis( "L_YAxis_" + id );

        Debug.Log( "ID: " + id + " h: " + h + ", v: " + v );

        if ( h == 0 && v == 0 ) {
            animator.speed = 0;
        } else {
            animator.speed = animationSpeed;
        }

        rigidbody2D.velocity = new Vector3( h * speed, -v * speed, 0 );
    }
}
