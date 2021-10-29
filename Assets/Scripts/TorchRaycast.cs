using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchRaycast : MonoBehaviour
{
    public int counter = 0 ;

    float raycastdist = 5f;
    bool hitPlayer;
    Vector2 raycastVector;
    void FixedUpdate(){
        if(Input.GetAxisRaw("Horizontal") > 0){
            raycastVector = Vector2.right;
        }
        if(Input.GetAxisRaw("Horizontal") < 0){
            raycastVector = Vector2.left;
        }

        if(gameObject.GetComponentInParent<TorchScript>().onPlayer == true){
            hitPlayer = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position,raycastVector,raycastdist);
            //Debug.Log(hit.collider.name);
            if(hit.collider.tag == "enemy"){
                hitPlayer = true;
                DestroyIf5();
            }
            Debug.DrawRay(transform.position,raycastVector * raycastdist,Color.blue);
        }
    }

    void DestroyIf5(){
        if(hitPlayer == true && counter <5){
            counter++;
            
        }else{
            Destroy(GameObject.Find("Torch"),1f);
        }
    }
}
