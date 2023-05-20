using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float iframecount = 0.3f;
    [SerializeField] float dodgespeed = 15;
    float originalvelocity;
    [SerializeField] float cooldown = 1.2f;
    float lastdodge = 0;
    float currentdodge = 0;
    PlayerMovement var;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentdodge = Time.time;
            if (currentdodge - lastdodge > cooldown)
            {
                var = transform.parent.GetComponent<PlayerMovement>();
                originalvelocity = var.speed;
                var.speed = originalvelocity + dodgespeed;
                Physics2D.IgnoreLayerCollision(8, 6, true);
                Physics2D.IgnoreLayerCollision(3, 6, true);
                Invoke("End", iframecount);
                lastdodge = currentdodge + iframecount;
            }
        }
    }
    void End()
    {
        var.speed = originalvelocity;
        Physics2D.IgnoreLayerCollision(8, 6, false);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }
}
