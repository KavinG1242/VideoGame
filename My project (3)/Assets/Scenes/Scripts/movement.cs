using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] private float speed = 3f;

    private Rigidbody2D body;
    private Vector2 axisMovement;
    private PlayerAnimations playerAnimations;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        axisMovement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        body.velocity = new Vector2(axisMovement.x*speed,body.velocity.y);
        CheckForFlipping();
        playerAnimations.SetMovement(axisMovement);  
    }

    private void CheckForFlipping()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if (movingLeft)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y);
        }
        if (movingRight)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y);
        }
    }
}
