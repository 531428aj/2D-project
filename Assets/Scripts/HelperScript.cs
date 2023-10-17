using UnityEngine;

public class HelperScript : MonoBehaviour
{
    public LayerMask groundLayer;

    private void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");

    }

    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    
    }
    public void GroundCheck(bool isGrounded)
    {
        Color rayColor = Color.white;
        bool grounded = (Physics2D.Raycast((new Vector2(transform.position.x, transform.position.y - 1f)), Vector3.up)); // raycast down to look for ground is not detecting ground? only works if allowing jump when grounded = false; // return "Ground" layer as layer

        if (grounded)
        {
            print("is grounded");
            rayColor = Color.blue;
        }
        else
        {
            
        }
        Debug.DrawRay((new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z)), Vector3.up, rayColor);

    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayer);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector2.up * rayLength, hitColor);

        return hitSomething;

    }
}
    

