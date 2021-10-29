using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{

    public bool onPlayer;
    public GameObject posT;


    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "player"){
            this.transform.parent = GameObject.Find("player").transform;
            transform.position = posT.transform.position;
            onPlayer = true;
        }
    }


}
