using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEffects : MonoBehaviour
{
    public AudioSource[] ad;

    int randommusic = 0;
    float randomTimer = 20f;
    float timeCounter = 0f;

    
    void Update()
    {
        if(timeCounter > randomTimer){
            randomTimer = Random.Range(1f,30f);
            timeCounter = 0f;
            chooseMusic();
        }
        
        timeCounter += Time.deltaTime;
    }
    
    void chooseMusic(){
        randommusic = Random.Range(0,10);
        switch(randommusic){
            case 0:
            ad[0].Play();
            break;
            case 1:
            ad[1].Play();
            break;
            case 2:
            ad[2].Play();
            break;
            case 4:
            ad[4].Play();
            break;
            case 5:
            ad[5].Play();
            break;
            case 6:
            ad[6].Play();
            break;
            case 7:
            ad[7].Play();
            break;
            case 8:
            ad[8].Play();
            break;
            case 9:
            ad[9].Play();
            break;
            case 10:
            ad[10].Play();
            break;
        }
    }
}
