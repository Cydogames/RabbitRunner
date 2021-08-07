using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController sharedInstance;

    public float jumpForce = 30.0f;
    public float runningSpeed = 5.0f;

    public LayerMask groundLayerMask;
    private Rigidbody2D myRigidbody2d;
    public Animator myAnimator;

    //-------------------------------------------------------------//

    private void Awake()
    {
        sharedInstance = this;
        myRigidbody2d = GetComponent<Rigidbody2D>();
        myAnimator.SetBool("isAlive", true);
    }

    private void Start()
    {
        myAnimator.SetBool("isAlive", true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        myAnimator.SetBool("isGrounded", IsGrounded());
    }

    private void FixedUpdate()
    {

        if (myRigidbody2d.velocity.x < runningSpeed)
        {
            myRigidbody2d.velocity = new Vector2(runningSpeed, myRigidbody2d.velocity.y);
        }

    }

    //------------------------------------------------------------//

    private void Jump()
    {
        if (IsGrounded())
        {
            myRigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }

    private bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value))
        {
            return true;

        }
        else return false;
    }


    public void IsDead()
    {
        myAnimator.SetBool("isAlive", false);
    }

}
