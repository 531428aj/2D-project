using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerScript : MonoBehaviour


{
    private Animator anim;
    float speed = 10.5f;
    public Vector2 boxSize;
    public float castDistance;
    
    HelperScript helper;
    bool isGrounded;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        print("Start");
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    
    void Update()
    {

        anim.SetBool("Running", false);
        anim.SetBool("Jump", false);

        isGrounded = helper.ExtendedRayCollisionCheck(0, -0.6f);


        if (Input.GetKeyDown("w") && isGrounded)
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode2D.Impulse);
            anim.SetBool("Jump", false);
         
        }
        if (isGrounded == false)
        {
            anim.SetBool("Jump", true);
        }

        if (Input.GetKey("a") == true)
        {
            transform.position = new Vector2(transform.position.x - (3 * Time.deltaTime), transform.position.y);
            anim.SetBool("Running", true);
            helper.FlipObject(true);
        }
        if (Input.GetKey("d") == true)
        {
            transform.position = new Vector2(transform.position.x + (3 * Time.deltaTime), transform.position.y);
            anim.SetBool("Running", true);

            helper.FlipObject(false);

        }
        if (Input.GetKey("e") == true)
        {
            anim.SetBool("Attack", true);
        }
        if (Input.GetKey("space"))
        {
            helper.FlipObject(true);
        }
    }

   
    }
 
    

  



