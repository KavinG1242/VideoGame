using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;
    public float groundedSkin = 0.05f;

    public LayerMask mask;

    bool jumpRequest;
    bool grounded;
    Vector2 playerSize;

    [SerializeField] bool groundedMid;
    [SerializeField] bool groundedRight;
    [SerializeField] bool groundedLeft;



    void Awake()
    {
        playerSize = GetComponent<BoxCollider2D>().size;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {

        if (jumpRequest)
        {
            //GetComponent<Rigidbody2D>().velocity += Vector2.up * jumpVelocity;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

            jumpRequest = false;
            grounded = false;
        }
        else

        {

            Vector2 Right = new Vector2(0.8f, 0f);
            Vector2 Left = new Vector2(-0.8f, 0f);

            Vector2 rayStart = (Vector2)transform.position + Vector2.down * playerSize.y * 0.5f;
            Vector2 rayRight = ((Vector2)transform.position + Right) + Vector2.down * playerSize.y * 0.5f;
            Vector2 rayLeft = ((Vector2)transform.position + Left) + Vector2.down * playerSize.y * 0.5f;

            groundedMid = Physics2D.Raycast(rayStart, Vector2.down, groundedSkin, mask);
            groundedRight = Physics2D.Raycast(rayRight, Vector2.down, groundedSkin, mask);
            groundedLeft = Physics2D.Raycast(rayLeft, Vector2.down, groundedSkin, mask);

            if ((groundedMid == true) || (groundedRight == true) || (groundedLeft == true))
            {
                grounded = true;
            }

        }
    }
}
