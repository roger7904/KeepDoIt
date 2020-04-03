﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorControlLeft : MonoBehaviour
{
    private Collider2D conveyorCollider;

    private float moveSpeed=0.05f;
    private float castdistance=0.8f;
    void Awake(){
        conveyorCollider = GetComponent<Collider2D>();
    }
    void Start()
    {
        conveyorCollider.enabled=false;

    }

    // Update is called once per frame
    void Update()
    {
        //conveyorCollider.enabled=false;

        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z), Vector2.left,castdistance);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            GameObject conveyGO=hit.collider.gameObject;
            conveyGO.transform.position=new Vector3(conveyGO.transform.position.x-moveSpeed,conveyGO.transform.position.y,conveyGO.transform.position.z);
        }

        //conveyorCollider.enabled=true;
    }

   
}
