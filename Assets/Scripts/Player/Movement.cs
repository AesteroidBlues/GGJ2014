using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Movement : MonoBehaviour {

    public int speed = 3;
    public float animationSpeed = 0.8f;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {
        PlayerIndex idx = GetComponent<Player>().GetIndex();

        Vector3 move = XInputManager.GetSticks( idx );

        if ( move == Vector3.zero ) {
            animator.speed = 0;
        } else {
            animator.speed = animationSpeed;
        }

        rigidbody2D.velocity = move * speed;
    }
}
