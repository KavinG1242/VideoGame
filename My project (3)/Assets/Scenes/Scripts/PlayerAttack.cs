using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  

    private GameObject attackArea = default;

    private bool attacking = false;

    private float TimetoAttack = 0.25f;
    private float timer = 0f;

    //private PlayerAnimations playerAnimations;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
       // playerAnimations = GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            
            Attack();
            
        }

        if(attacking)
        {
            timer += Time.deltaTime;
            if(timer>=TimetoAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                
            }
        }
        //playerAnimations.SetAttack(attacking);
    }

    private void Attack()
    {
        attacking = true;
         attackArea.SetActive(attacking);
   
    }
   
            
     
}
