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
    Movement var;
    
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
                var = transform.parent.GetComponent<Movement>();
                originalvelocity = var.speed;
                var.speed = originalvelocity + dodgespeed;
                transform.gameObject.layer = 0;
                Invoke("End",iframecount);
                lastdodge = currentdodge + iframecount;
            }
        }
    }
    void End()
    {
        var.speed = originalvelocity;
        transform.gameObject.layer = 8;
    }
}
