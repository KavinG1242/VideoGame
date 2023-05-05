using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            
            animator.SetBool("attacking", true);
        }
        else
        {
           
            animator.SetBool("attacking", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            animator.SetBool("Jump", true);
        }
        else
        {

            animator.SetBool("Jump", false);
        }
    }
public void SetMovement(Vector2 movement)
    {
        animator.SetFloat("Movement", Mathf.Abs(movement.x));
    }


}
