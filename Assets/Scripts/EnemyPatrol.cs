using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    HelperScript helper;
    public float speed;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("Enemy walk", true);
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = helper.ExtendedRayCollisionCheck(0, -0.4f);
        if (isGrounded == false)
        {
            helper.FlipObject(true);
        }

    }
    private void OnDrawGizmos()
    {
     
    }
}
    
    

