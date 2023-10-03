using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerScript : MonoBehaviour


{
    private Animator anim;
    SpriteRenderer sr;
    float speed = 3.5f;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        print("Start");
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    Rigidbody2D rd;
    void Update()
    {
        GroundCheck();

        anim.SetBool("Running", false);


        rd = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown("w") == true)
        {
            rd.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey("a") == true)
        {
            transform.position = new Vector2(transform.position.x - (1 * Time.deltaTime), transform.position.y);
            anim.SetBool("Running", true);
            sr.flipX = true;
        }
        if (Input.GetKey("d") == true)
        {
            transform.position = new Vector2(transform.position.x + (1 * Time.deltaTime), transform.position.y);
            sr.flipX = false;
            anim.SetBool("Running", true);
        }
        
        {

        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer ))
        {
            print("is grounded");
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
 
    }

    void GroundCheck()
    {
        Color rayColor = Color.white;
        bool grounded = (Physics2D.Raycast((new Vector2(transform.position.x, transform.position.y - 1f)), Vector3.up )); // raycast down to look for ground is not detecting ground? only works if allowing jump when grounded = false; // return "Ground" layer as layer

        if (grounded)
        {
            
            anim.SetBool("Jump", false);
            
        }
        else
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Running", false);
        }

        Debug.DrawRay((new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z)), Vector3.up, rayColor);

    }


}

    


