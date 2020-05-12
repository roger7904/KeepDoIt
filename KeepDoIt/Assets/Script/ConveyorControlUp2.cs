﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorControlUp2 : MonoBehaviour
{
    private Collider2D conveyorCollider;

    private float moveSpeed=0.04f;
    private float castdistance=1.8f;
    void Awake(){
        conveyorCollider = GetComponent<Collider2D>();
    }
    void Start()
    {
        //conveyorCollider.enabled=false;

    }

    // Update is called once per frame
    void Update()
    {
        //conveyorCollider.enabled=false;

        RaycastHit2D[] hitarray = Physics2D.RaycastAll(new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z), Vector2.up,castdistance);
        foreach(RaycastHit2D hit in hitarray){
            if (hit.collider != null)
            {
                if(hit.collider.transform.tag!="Player" && hit.collider.transform.tag!="Conveyor"){
                    //Debug.Log(hit.collider.name);
                    GameObject conveyGO=hit.collider.gameObject;
                    conveyGO.transform.position=new Vector3(conveyGO.transform.position.x,conveyGO.transform.position.y+moveSpeed,conveyGO.transform.position.z);
                }
                
            }
        }
        

        //conveyorCollider.enabled=true;
    }

   
}
