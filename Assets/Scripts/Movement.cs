using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        anim.SetFloat("speed",Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if(Input.GetAxisRaw("Horizontal") > 0){
            transform.Translate(new Vector3(5f,0f,0f) * Time.deltaTime);
            rb.AddForce(new Vector2(-1f,0f) * Time.deltaTime);
            anim.SetBool("isRight",true);
            anim.SetBool("isLeft",false);
            //GameObject.Find("pointer").GetComponent<Transform>().localRotation = Quaternion.Euler(0f,0f,0f);
        }else if(Input.GetAxisRaw("Horizontal") < 0){
            transform.Translate(new Vector3(-5f,0f,0f) * Time.deltaTime);
            rb.AddForce(new Vector2(-1f,0f) * Time.deltaTime);
            anim.SetBool("isRight",false);
            anim.SetBool("isLeft",true); 
            //GameObject.Find("pointer").GetComponent<Transform>().localRotation = Quaternion.Euler(0f,-180,0f);
        }
        if(GameObject.Find("GroundCheck").GetComponent<groundCheck>().isgrounded == true && Input.GetButtonDown("Jump")){
            rb.AddForce(new Vector2(0f,5f),ForceMode2D.Impulse);
            GameObject.Find("GroundCheck").GetComponent<groundCheck>().isgrounded = false;
        }
    }
}
