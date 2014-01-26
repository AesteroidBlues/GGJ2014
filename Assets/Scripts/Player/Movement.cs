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

        bool canMove = gameObject.GetComponent<Player>().CanMove;

        if ( move == Vector3.zero  || !canMove) {
            animator.speed = 0;
        } else {
            animator.speed = animationSpeed;
        }

        if (canMove)
            rigidbody2D.velocity = move * speed;
        else
            rigidbody2D.velocity = Vector3.zero;
    }
}
