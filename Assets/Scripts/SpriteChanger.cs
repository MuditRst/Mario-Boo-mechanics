using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public void changeSprite(bool change,RaycastHit2D hit,Sprite sp,Material mat){
        if(change){
            hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = sp;
            hit.collider.gameObject.GetComponent<SpriteRenderer>().material = mat;
        }
    }
}
