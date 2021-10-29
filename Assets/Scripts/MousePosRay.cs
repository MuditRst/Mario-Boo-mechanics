using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosRay : MonoBehaviour
{
    public Camera cam;

    float dist = 7.5f;
    Vector2 camPos;
    Vector2 Pos;
    public bool isseen,isrev,right,left,inair,rightair,leftair;

    public Sprite[] spritechange,airenemysprite;
    public Material[] materialchange,airenemymaterial;

    public Sprite[] originalSprite,ogairenemysprite;
    public Material[] originalMaterial,ogairenemymaterial;

    public LayerMask mask;

    private RaycastHit2D saveHit,hitsave;

    void Update()
    {
        camPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Pos = camPos - GetComponentInParent<Rigidbody2D>().position;
        ///     a    -    b
        Pos.x = Mathf.Clamp(Pos.x,-180f,180f);
        Pos.y = Mathf.Clamp(Pos.y,-180f,180f);
    }

    void FixedUpdate(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Pos,dist,mask);
        if(hit.collider != null){
            //Debug.Log(hit.collider.name);
            saveHit = hit;
            if(hit.collider.tag == "enemy" && Vector2.Distance(transform.position,hit.collider.gameObject.transform.position) <= 10f){
                isseen = true;
                if(hit.collider.GetComponent<Transform>().position.x > transform.position.x){
                    right = true;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = spritechange[0];
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().material = materialchange[0];
                }
                if(hit.collider.GetComponent<Transform>().position.x < transform.position.x){
                    left = true;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = spritechange[1];
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().material = materialchange[1];
                }

                if(left){
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f,0f),ForceMode2D.Impulse);
                    //Debug.Log("Left");
                }
                if(right){
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f,0f),ForceMode2D.Impulse);
                    //Debug.Log("right");
                }

                isrev = true;
            }

            if(hit.collider.tag == "AirEnemy" && Vector2.Distance(transform.position,hit.collider.gameObject.transform.position) <= 10f){
                isseen = true;
                hitsave = hit;
                //Debug.Log(saveHit.collider.name);
                inair = true;
                if(hit.collider.transform.position.x > transform.position.x){
                    rightair = true;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = airenemysprite[0];
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().material = airenemymaterial[0];
                }

                if(hit.collider.transform.position.x < transform.position.x){
                    leftair = true;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = airenemysprite[1];
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().material = airenemymaterial[1];
                }

                if(rightair){
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.75f,0.5f),ForceMode2D.Impulse);
                }

                if(leftair){
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.75f,0.5f),ForceMode2D.Impulse);
                }

                isrev = true;
            }

        }


        Debug.DrawRay(transform.position,Pos * dist,Color.magenta);

        if(Vector2.Distance(saveHit.collider.gameObject.transform.position,transform.position) > 13f && isrev == true && right == true){
            saveHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite[0];
            saveHit.collider.gameObject.GetComponent<SpriteRenderer>().material = originalMaterial[0];
            saveHit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            right = false;
            isrev = false;
        }

        if(Vector2.Distance(saveHit.collider.gameObject.transform.position,transform.position) > 13f && isrev == true && left == true){
            saveHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite[1];
            saveHit.collider.gameObject.GetComponent<SpriteRenderer>().material = originalMaterial[1];
            saveHit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            left = false;
            isrev = false;
        }

        if(Vector2.Distance(hitsave.collider.gameObject.transform.position,transform.position) > 13f && isrev == true && rightair == true && inair == true){
            hitsave.collider.gameObject.GetComponent<SpriteRenderer>().sprite = ogairenemysprite[0];
            hitsave.collider.gameObject.GetComponent<SpriteRenderer>().material = ogairenemymaterial[0];
            hitsave.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            rightair = false;
            isrev = false;
        }

        if(Vector2.Distance(hitsave.collider.gameObject.transform.position,transform.position) > 13f && isrev == true && leftair == true && inair == true){
            hitsave.collider.gameObject.GetComponent<SpriteRenderer>().sprite = ogairenemysprite[1];
            hitsave.collider.gameObject.GetComponent<SpriteRenderer>().material = ogairenemymaterial[1];
            hitsave.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            leftair = false;
            isrev = false;

        }

        isseen = false;
    }
}