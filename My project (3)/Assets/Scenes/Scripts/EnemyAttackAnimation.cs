using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnimation : MonoBehaviour
{
    private GameObject attackArea = default;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool attacking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
       
            animator.SetBool("attacking", attacking);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            attacking=true;
        }
        else if(!other.gameObject.CompareTag("Player"))
        {
            attacking = false;
        }
    }


    
}
