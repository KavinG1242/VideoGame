using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    [SerializeField][Range(0f, 1f)] float LagAmount = 0f;

    Vector3 startingPosition;
    Transform cam;
    Vector3 targetPosition;

    private float ParallaxAmount => 1f - LagAmount;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        startingPosition = cam.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = cameraMovement;

        if (movement == Vector3.zero)
        {
            return;
        }

        else
        {
            targetPosition = new Vector3(transform.position.x + movement.x * ParallaxAmount, transform.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }

    Vector3 cameraMovement
    {
        get
        {
            Vector3 movement = cam.position - startingPosition;
            startingPosition = cam.position;
            return movement;
        }
    }
}
