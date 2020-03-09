using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformlayermask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxcollider2d;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<UnityEngine.Rigidbody2D>();
        boxcollider2d = transform.GetComponent<BoxCollider2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 7f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        if (IsGrounded()) HandleMovement();

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0f, Vector2.down, .1f, platformlayermask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement()
    {
        float moveSpeed = 3f;
        float midAirControl = 115f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (IsGrounded())
            {
                rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                rigidbody2d.velocity += new Vector2(-moveSpeed*midAirControl , 0);
                rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (IsGrounded())
                {
                    rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                }
                else
                {
                    
                    rigidbody2d.velocity += new Vector2(+moveSpeed * midAirControl , 0);
                    rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
                }
            }
            else
            {
                if (IsGrounded())
                {
                    rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                }
            }
        }
    }



}
