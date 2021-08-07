using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 30.0f;

    public LayerMask groundLayerMask;
    private Rigidbody2D myRigidbody2d;
    public Animator myAnimator;

    //-------------------------------------------------------------//

    void Awake()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        myAnimator.SetBool("isAlive", true);
    }

    void Start()
    {
        myAnimator.SetBool("isAlive", true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        myAnimator.SetBool("isGrounded", isGrounded());
    }

    void FixedUpdate()
    {
        
    }

    //------------------------------------------------------------//

    void Jump()
    {
        if (isGrounded())
        {
            myRigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
        
    }

    bool isGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value)){
            return true;

        } else return false;
    }

}
