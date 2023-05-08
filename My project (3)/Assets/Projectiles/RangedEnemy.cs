using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float t = 2f;
    private bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer > t)
            {
                timer = 0;
                shoot();

            }

            animator.SetBool("attacking", true);

        }

        else
        {
            animator.SetBool("attacking", false);
        }


    }

    void shoot()
    {
        attacking = true;
        Instantiate(bullet, bulletPos.position, Quaternion.identity);

    }
}
