using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool itemCol;

    public void Torch(){
        if(itemCol == true){
           GameObject.Find("playerTorch").SetActive(true);
        }
    }
}
