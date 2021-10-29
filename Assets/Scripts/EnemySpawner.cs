using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] flyingenemy;

    public Transform[] groundspawns,airspawns;

    private GameObject[] en,fen;
    void Start()
    {
        fen = GameObject.FindGameObjectsWithTag("AirEnemy");
        en = GameObject.FindGameObjectsWithTag("enemy");
    }

    void Update()
    {
        if(fen.Length == 0){
            GameObject temp1 = Instantiate(flyingenemy[0],airspawns[0]);
            GameObject temp2 = Instantiate(flyingenemy[1],airspawns[1]);

            if(temp1.transform.position.y > 20f){
                Destroy(temp1,1f);
            }
            if(temp2.transform.position.y > 20f){
                Destroy(temp2,1f);
            }
        }

        if(en.Length == 0){
            GameObject temp1 = Instantiate(enemy[0],groundspawns[0]);
            GameObject temp2 =  Instantiate(enemy[1],groundspawns[1]);

            if(temp1.transform.position.x > 20f){
                Destroy(temp1,1f);
            }
            if(temp2.transform.position.x > 20f){
                Destroy(temp2,1f);
            }
        }
    }
}
