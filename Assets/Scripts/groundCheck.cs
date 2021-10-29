using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool isgrounded;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Floor"){
            //Debug.Log(col.gameObject.name);
            isgrounded = true;
        }
    }
}
