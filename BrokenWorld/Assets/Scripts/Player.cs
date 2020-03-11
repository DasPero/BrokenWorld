using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformlayermask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxcollider2d;
    public GameManager TheGameManager;
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
    public float Speed = 5.0f;

    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);



        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 5f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "kill")
        {
            TheGameManager.Restart();
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0f, Vector2.down, .1f, platformlayermask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }





}
