using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{

    private int damage = 1;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.parent.GetComponent<Health>() != null && (collider.gameObject.layer == 8))
        {
            Health health = collider.transform.parent.GetComponent<Health>();
            health.Damage(damage);


        }
    }

}
