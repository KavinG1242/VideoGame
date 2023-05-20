using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float jumpForce;
    [SerializeField] public LayerMask GroundLayer;
    [SerializeField] public LayerMask WallLayer;
    [SerializeField] public bool ground;
    [SerializeField] public bool wall;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCoolDown;
    private float horizontalInput;
    private float verticalInput;
    private Vector2 axisMovement;
    private PlayerAnimations playerAnimations;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        axisMovement.x = horizontalInput;
        axisMovement.y = verticalInput;

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetBool("grounded", isGrounded());
        playerAnimations.SetMovement(axisMovement);

        if (wallJumpCoolDown > 0.2f)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

            if (onWall() && !isGrounded())
            {
                rb.gravityScale = 4;
                rb.velocity = Vector2.zero;
            }

            else
            {
                rb.gravityScale = 1;
            }


            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (onWall() || isGrounded()))
            {
                Jump();
            }
        }

        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }

        ground = isGrounded();
        wall = onWall();
    }

    private void Jump()
    {

        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("jump");
        }

        else if (onWall() && !isGrounded())
        {


            if (horizontalInput == 0)
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            else
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 8, 16);
            }

            wallJumpCoolDown = 0;

        }
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, GroundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, WallLayer);
        return raycastHit.collider != null;
    }
}
