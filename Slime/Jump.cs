using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;

    bool jumpRequest;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
        }
    }
}
