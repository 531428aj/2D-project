using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Object = System.Object;

public class PlayerScript : MonoBehaviour


{
    private Animator anim;
    float speed = 10.5f;
    public Vector2 boxSize;
    public float castDistance;

    HelperScript helper;
    bool isGrounded;
    Rigidbody2D rb;
    public GameObject weapon;


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
        if (Input.GetKey("l") == true)
        {
            anim.SetBool("Attack", true);
        }
        if (Input.GetKey("space"))
        {
            helper.FlipObject(true);
        }
        int moveDirection = 1;
        if (Input.GetKeyDown("e"))
        {
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(weapon, transform.position, transform.rotation);


            // get the rigidbody component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();


            // set the velocity
            rb.velocity = new Vector3(15 * moveDirection, 0, 0);


            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 0, transform.position.z + 1);
        }

    }
}