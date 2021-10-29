using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    bool raycastbool;
    Rigidbody2D rb;

    void Start(){
        raycastbool = GameObject.Find("player").GetComponent<MousePosRay>().isseen;
    }
    void Update(){
        if(raycastbool != true){
            transform.position = Vector2.MoveTowards(transform.position,GameObject.Find("player").transform.position,1f * Time.deltaTime);
        }
    }
}
