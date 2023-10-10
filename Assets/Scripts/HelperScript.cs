using UnityEngine;

public class HelperScript : MonoBehaviour
{

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
    void GroundCheck()
    {
        Color rayColor = Color.white;
        bool grounded = (Physics2D.Raycast((new Vector2(transform.position.x, transform.position.y - 1f)), Vector3.up)); // raycast down to look for ground is not detecting ground? only works if allowing jump when grounded = false; // return "Ground" layer as layer

        if (grounded)
        {
            print("is grounded");
        }
        else
        {
            
        }

        Debug.DrawRay((new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z)), Vector3.up, rayColor);

    }
}
    

