using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public Sprite spriteR,spriteL;
    public Material matR,matL;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.x > GameObject.Find("player").transform.position.x){
            GetComponent<SpriteRenderer>().sprite = spriteL;
            GetComponent<SpriteRenderer>().material = matL;
        }
        if(transform.position.x < GameObject.Find("player").transform.position.x){
            GetComponent<SpriteRenderer>().sprite = spriteR;
            GetComponent<SpriteRenderer>().material = matR;
        }
    }
}
