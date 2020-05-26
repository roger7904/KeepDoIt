﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CastbtnControl : MonoBehaviour
{
    private RaycastHit2D[] hitarray;
    private string status;
    private PhotonView PV;
    private Collider2D playerGOCollider;
    public GameObject cloth1_c;
    public GameObject cloth1_n;
    public GameObject cloth2_c;
    public GameObject cloth2_n;
    public GameObject cloth3_c;
    public GameObject cloth3_n;
    public GameObject cloth4_c;
    public GameObject cloth4_n;
    public GameObject cloth1_blue;
    public GameObject cloth1_green;
    public GameObject cloth1_red;
    public GameObject cloth2_blue;
    public GameObject cloth2_green;
    public GameObject cloth2_red;
    public GameObject cloth3_blue;
    public GameObject cloth3_green;
    public GameObject cloth3_red;
    public GameObject cloth4_blue;
    public GameObject cloth4_green;
    public GameObject cloth4_purple;
    public GameObject cloth4_purple_c;
    public GameObject cloth3_yello;
    public GameObject cloth3_yello_c;
    public GameObject cloth4_red;
    public GameObject cloth1_blue_c;
    public GameObject cloth1_green_c;
    public GameObject cloth1_red_c;
    public GameObject cloth2_blue_c;
    public GameObject cloth2_green_c;
    public GameObject cloth2_red_c;
    public GameObject cloth3_blue_c;
    public GameObject cloth3_green_c;
    public GameObject cloth3_red_c;
    public GameObject cloth4_blue_c;
    public GameObject cloth4_green_c;
    public GameObject cloth4_red_c;
    public GameObject clothmix;
    public GameObject clothmix_c;
    public GameObject pai_ban;
    public GameObject pai_ban_c;
    public GameObject da_ban;
    public GameObject da_ban_c;
    public GameObject carton;
    public GameObject carton_c;
    public GameObject pai_ban_blue;
    public GameObject pai_ban_blue_c;
    public GameObject pai_ban_green;
    public GameObject pai_ban_green_c;

    public GameObject pai_ban_red;
    public GameObject pai_ban_red_c;
    public GameObject pai_ban_mix;
    public GameObject pai_ban_mix_c;
    public GameObject pai_ban_yello;
    public GameObject pai_ban_yello_c;
    public GameObject pai_ban_purple;
    public GameObject pai_ban_purple_c;
    public GameObject cloth1_tailor;
    public GameObject cloth1_tailor_c;
    public GameObject cloth1_done;
    public GameObject cloth1_done_c;
    public GameObject clothmix_tailor;
    public GameObject clothmix_tailor_c;
    public GameObject clothmix_done;
    public GameObject clothmix_done_c;
    public GameObject cloth2_tailor;
    public GameObject cloth2_tailor_c;
    public GameObject cloth2_done;
    public GameObject cloth2_done_c;
    public GameObject cloth3_tailor;
    public GameObject cloth3_tailor_c;
    public GameObject cloth3_done;
    public GameObject cloth3_done_c;
    public GameObject cloth4_tailor;
    public GameObject cloth4_tailor_c;
    public GameObject cloth4_done;
    public GameObject cloth4_done_c;


    private GameObject playerGO;
    
    private GameObject insGO;
    private bool flag1;
    private bool flag2;
    private bool flag3;
    private bool flag4;
    private int GOnumber;

    void Start(){
        PV=GetComponent<PhotonView>();  
        status="none";
        flag1=false;
        flag2=false;
        flag3=false;
        flag4=false;
        GOnumber=1;
    }
    void Update(){
        playerGO = PhotonView.Find(PlayerControl.ID).gameObject;
    }
    public void cast(){
        playerGOCollider = playerGO.GetComponent<Collider2D>();
        playerGOCollider.enabled=false;
        Debug.Log("call cast function status:"+status);
        if(PlayerControl.playerDirection==Vector2.down){
            hitarray=Physics2D.RaycastAll(playerGO.transform.position, PlayerControl.playerDirection,1.5f);
        }else{
            hitarray=Physics2D.RaycastAll(playerGO.transform.position, PlayerControl.playerDirection,1f);
        }
        foreach (RaycastHit2D hit in hitarray){
            if(hit.collider.transform.tag=="Work" && status!="none"){
                flag1=true;
            }else if(hit.collider.transform.tag!="Work" && status!="none"){
                flag2=true;
            }else if(hit.collider.transform.tag!="Work" && status=="none"){
                flag3=true;
            }else if(hit.collider.transform.tag=="Work" && status=="none"){
                flag4=true;
            }
        }
        if(flag1 && flag2){
            foreach (RaycastHit2D hit in hitarray)
            {
                if((hit.collider.transform.tag=="Pai_ban" && status=="cloth1_blue") || (hit.collider.transform.tag=="Cloth1_blue" && status=="pai_ban")){
                    status="cloth1_pai_ban";
                    PV.RPC("cloth1_pai_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                }else if((hit.collider.transform.tag=="Pai_ban" && status=="clothmix") || (hit.collider.transform.tag=="Clothmix" && status=="pai_ban")){
                    status="clothmix_pai_ban";
                    PV.RPC("clothmix_pai_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                }else if((hit.collider.transform.tag=="Pai_ban" && status=="cloth2_green") || (hit.collider.transform.tag=="Cloth2_green" && status=="pai_ban")){
                    status="cloth2_pai_ban";
                    PV.RPC("cloth2_pai_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                }else if((hit.collider.transform.tag=="Pai_ban" && status=="cloth3_yello") || (hit.collider.transform.tag=="Cloth3_yello" && status=="pai_ban")){
                    status="cloth3_pai_ban";
                    PV.RPC("cloth3_pai_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                }else if((hit.collider.transform.tag=="Pai_ban" && status=="cloth4_purple") || (hit.collider.transform.tag=="Cloth4_purple" && status=="pai_ban")){
                    status="cloth4_pai_ban";
                    PV.RPC("cloth4_pai_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                }else if((hit.collider.transform.tag=="Pai_ban" && status=="cloth1_red") || (hit.collider.transform.tag=="Cloth1_red" && status=="pai_ban") || (hit.collider.transform.tag=="Pai_ban" && status=="cloth2_red") || (hit.collider.transform.tag=="Cloth2_red" && status=="pai_ban") || (hit.collider.transform.tag=="Pai_ban" && status=="cloth3_red") || (hit.collider.transform.tag=="Cloth3_red" && status=="pai_ban") || (hit.collider.transform.tag=="Pai_ban" && status=="cloth4_red") || (hit.collider.transform.tag=="Cloth4_red" && status=="pai_ban")){
                    status="pai_ban_red";
                    PV.RPC("pai_ban_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                }
            }
        }else if(flag3 && flag4){
            foreach (RaycastHit2D hit in hitarray)
            {
                if (hit.collider != null)
                {
                    if(hit.collider.transform.tag=="Cloth1_take" && status=="none"){
                        status="cloth1";
                        PV.RPC("cloth1_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1" && status=="none"){
                        status="cloth1";
                        PV.RPC("cloth1RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_take" && status=="none"){
                        status="cloth2";
                        PV.RPC("cloth2_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2" && status=="none"){
                        status="cloth2";
                        PV.RPC("cloth2RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_take" && status=="none"){
                        status="cloth3";
                        PV.RPC("cloth3_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3" && status=="none"){
                        status="cloth3";
                        PV.RPC("cloth3RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_take" && status=="none"){
                        status="cloth4";
                        PV.RPC("cloth4_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4" && status=="none"){
                        status="cloth4";
                        PV.RPC("cloth4RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Conveyor" && status!="none"){
                        status="none";
                        PV.RPC("conveyorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.transform.position,hit.collider.transform.rotation,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_blue" && status=="none"){
                        status="cloth1_blue";
                        PV.RPC("cloth1_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_green" &&  status=="none"){
                        status="cloth1_green";
                        PV.RPC("cloth1_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_red" && status=="none"){
                        status="cloth1_red";
                        PV.RPC("cloth1_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_blue" && status=="none"){
                        status="cloth2_blue";
                        PV.RPC("cloth2_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_green" &&  status=="none"){
                        PV.RPC("cloth2_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_red" && status=="none"){
                        status="cloth2_red";
                        PV.RPC("cloth2_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_blue" && status=="none"){
                        status="cloth3_blue";
                        PV.RPC("cloth3_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_green" &&  status=="none"){
                        status="cloth3_green";
                        PV.RPC("cloth3_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_red" && status=="none"){
                        status="cloth3_red";
                        PV.RPC("cloth3_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_blue" && status=="none"){
                        status="cloth4_blue";
                        PV.RPC("cloth4_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_green" &&  status=="none"){
                        status="cloth4_green";
                        PV.RPC("cloth4_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_red" && status=="none"){
                        status="cloth4_red";
                        PV.RPC("cloth4_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="blue" && status=="cloth1"){
                        status="cloth1_blue";
                        PV.RPC("blueyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="blue" && status=="cloth2"){
                        status="cloth2_blue";
                        PV.RPC("blueyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="blue" && status=="cloth3"){
                        status="cloth3_blue";
                        PV.RPC("blueyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="blue" && status=="cloth4"){
                        status="cloth4_blue";
                        PV.RPC("blueyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="green" && status=="cloth1"){
                        status="cloth1_green";
                        PV.RPC("greenyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="green" && status=="cloth2"){
                        status="cloth2_green";
                        PV.RPC("greenyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="green" && status=="cloth3"){
                        status="cloth3_green";
                        PV.RPC("greenyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="green" && status=="cloth4"){
                        status="cloth4_green";
                        PV.RPC("greenyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="red" && status=="cloth1"){
                        status="cloth1_red";
                        PV.RPC("redyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="red" && status=="cloth2"){
                        status="cloth2_red";
                        PV.RPC("redyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="red" && status=="cloth3"){
                        status="cloth3_red";
                        PV.RPC("redyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="red" && status=="cloth4"){
                        status="cloth4_red";
                        PV.RPC("redyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_take" && (status=="cloth2" ||status=="cloth3" || status=="cloth4")){
                        status="clothmix";
                        PV.RPC("clothmixRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_take" && (status=="cloth1" ||status=="cloth3" || status=="cloth4")){
                        status="clothmix";
                        PV.RPC("clothmixRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_take" && (status=="cloth2" ||status=="cloth1" || status=="cloth4")){
                        status="clothmix";
                        PV.RPC("clothmixRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_take" && (status=="cloth2" ||status=="cloth3" || status=="cloth1")){
                        status="clothmix";
                        PV.RPC("clothmixRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Clothmix" && status=="none"){
                        status="clothmix";
                        PV.RPC("clothmix_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Carton_take" && status=="none"){
                        status="carton";
                        PV.RPC("carton_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Carton" && status=="none"){
                        status="carton";
                        PV.RPC("cartonRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Trashcan" && status!="none"){
                        status="none";
                        PV.RPC("trashcanRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                    }else if(hit.collider.transform.tag=="Da_ban_take" && status=="none"){
                        status="da_ban";
                        PV.RPC("da_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Da_ban" && status=="none"){
                        status="da_ban";
                        PV.RPC("da_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban" && status=="none"){
                        status="pai_ban";
                        PV.RPC("pai_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_take" && status=="da_ban"){
                        status="pai_ban";
                        PV.RPC("pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_blue" && status=="none"){
                        status="cloth1_pai_ban";
                        PV.RPC("cloth1_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="cloth1_pai_ban"){
                        status="cloth1_tailor";
                        PV.RPC("cloth1_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_tailor" && status=="none"){
                        status="cloth1_tailor";
                        PV.RPC("cloth1_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="cloth1_tailor"){
                        status="cloth1_done";
                        PV.RPC("cloth1_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_done" && status=="none"){
                        status="cloth1_done";
                        PV.RPC("cloth1_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_mix" && status=="none"){
                        status="clothmix_pai_ban";
                        PV.RPC("clothmix_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="clothmix_pai_ban"){
                        status="clothmix_tailor";
                        PV.RPC("clothmix_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Clothmix_tailor" && status=="none"){
                        status="clothmix_tailor";
                        PV.RPC("clothmix_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="clothmix_tailor"){
                        status="clothmix_done";
                        PV.RPC("clothmix_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Clothmix_done" && status=="none"){
                        status="clothmix_done";
                        PV.RPC("clothmix_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_green" && status=="none"){
                        status="cloth2_pai_ban";
                        PV.RPC("cloth2_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="cloth2_pai_ban"){
                        status="cloth2_tailor";
                        PV.RPC("cloth2_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_tailor" && status=="none"){
                        status="cloth2_tailor";
                        PV.RPC("cloth2_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="cloth2_tailor"){
                        status="cloth2_done";
                        PV.RPC("cloth2_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_done" && status=="none"){
                        status="cloth2_done";
                        PV.RPC("cloth2_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if((hit.collider.transform.tag=="blue" && status=="cloth4_red") || (hit.collider.transform.tag=="red" && status=="cloth4_blue")){
                    status="cloth4_purple";
                    PV.RPC("cloth4_purple_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_purple" && status=="none"){
                        status="cloth4_purple";
                        PV.RPC("cloth4_purpleRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if((hit.collider.transform.tag=="green" && status=="cloth3_red") || (hit.collider.transform.tag=="red" && status=="cloth3_green")){
                    status="cloth3_yello";
                    PV.RPC("cloth3_yello_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_yello" && status=="none"){
                        status="cloth3_yello";
                        PV.RPC("cloth3_yelloRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_yello" && status=="none"){
                        status="cloth3_pai_ban";
                        PV.RPC("cloth3_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="cloth3_pai_ban"){
                        status="cloth3_tailor";
                        PV.RPC("cloth3_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_tailor" && status=="none"){
                        status="cloth3_tailor";
                        PV.RPC("cloth3_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="cloth3_tailor"){
                        status="cloth3_done";
                        PV.RPC("cloth3_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_done" && status=="none"){
                        status="cloth3_done";
                        PV.RPC("cloth3_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_purple" && status=="none"){
                        status="cloth4_pai_ban";
                        PV.RPC("cloth4_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="cloth4_pai_ban"){
                        status="cloth4_tailor";
                        PV.RPC("cloth4_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_tailor" && status=="none"){
                        status="cloth4_tailor";
                        PV.RPC("cloth4_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="cloth4_tailor"){
                        status="cloth4_done";
                        PV.RPC("cloth4_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_done" && status=="none"){
                        status="cloth4_done";
                        PV.RPC("cloth4_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_red" && status=="none"){
                        status="pai_ban_red";
                        PV.RPC("red_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }    
                }
            }
        }else{
            foreach (RaycastHit2D hit in hitarray)
            {
                if (hit.collider != null)
                {
                    if(hit.collider.transform.tag=="Cloth1_take" && status=="none"){
                        status="cloth1";
                        PV.RPC("cloth1_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1" && status=="none"){
                        status="cloth1";
                        PV.RPC("cloth1RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_take" && status=="none"){
                        status="cloth2";
                        PV.RPC("cloth2_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2" && status=="none"){
                        status="cloth2";
                        PV.RPC("cloth2RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_take" && status=="none"){
                        status="cloth3";
                        PV.RPC("cloth3_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3" && status=="none"){
                        status="cloth3";
                        PV.RPC("cloth3RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_take" && status=="none"){
                        status="cloth4";
                        PV.RPC("cloth4_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4" && status=="none"){
                        status="cloth4";
                        PV.RPC("cloth4RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Conveyor" && status!="none"){
                        status="none";
                        PV.RPC("conveyorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.transform.position,hit.collider.transform.rotation,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_blue" && status=="none"){
                        status="cloth1_blue";
                        PV.RPC("cloth1_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_green" &&  status=="none"){
                        status="cloth1_green";
                        PV.RPC("cloth1_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_red" && status=="none"){
                        status="cloth1_red";
                        PV.RPC("cloth1_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_blue" && status=="none"){
                        status="cloth2_blue";
                        PV.RPC("cloth2_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_green" &&  status=="none"){
                        PV.RPC("cloth2_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_red" && status=="none"){
                        status="cloth2_red";
                        PV.RPC("cloth2_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_blue" && status=="none"){
                        status="cloth3_blue";
                        PV.RPC("cloth3_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_green" &&  status=="none"){
                        status="cloth3_green";
                        PV.RPC("cloth3_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_red" && status=="none"){
                        status="cloth3_red";
                        PV.RPC("cloth3_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_blue" && status=="none"){
                        status="cloth4_blue";
                        PV.RPC("cloth4_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_green" &&  status=="none"){
                        status="cloth4_green";
                        PV.RPC("cloth4_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_red" && status=="none"){
                        status="cloth4_red";
                        PV.RPC("cloth4_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="blue" && status=="cloth1"){
                        status="cloth1_blue";
                        PV.RPC("blueyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="blue" && status=="cloth2"){
                        status="cloth2_blue";
                        PV.RPC("blueyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="blue" && status=="cloth3"){
                        status="cloth3_blue";
                        PV.RPC("blueyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="blue" && status=="cloth4"){
                        status="cloth4_blue";
                        PV.RPC("blueyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="green" && status=="cloth1"){
                        status="cloth1_green";
                        PV.RPC("greenyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="green" && status=="cloth2"){
                        status="cloth2_green";
                        PV.RPC("greenyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="green" && status=="cloth3"){
                        status="cloth3_green";
                        PV.RPC("greenyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="green" && status=="cloth4"){
                        status="cloth4_green";
                        PV.RPC("greenyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="red" && status=="cloth1"){
                        status="cloth1_red";
                        PV.RPC("redyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="red" && status=="cloth2"){
                        status="cloth2_red";
                        PV.RPC("redyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="red" && status=="cloth3"){
                        status="cloth3_red";
                        PV.RPC("redyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="red" && status=="cloth4"){
                        status="cloth4_red";
                        PV.RPC("redyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_take" && (status=="cloth2" ||status=="cloth3" || status=="cloth4")){
                        status="clothmix";
                        PV.RPC("clothmixRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_take" && (status=="cloth1" ||status=="cloth3" || status=="cloth4")){
                        status="clothmix";
                        PV.RPC("clothmixRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_take" && (status=="cloth2" ||status=="cloth1" || status=="cloth4")){
                        status="clothmix";
                        PV.RPC("clothmixRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_take" && (status=="cloth2" ||status=="cloth3" || status=="cloth1")){
                        status="clothmix";
                        PV.RPC("clothmixRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Clothmix" && status=="none"){
                        status="clothmix";
                        PV.RPC("clothmix_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Carton_take" && status=="none"){
                        status="carton";
                        PV.RPC("carton_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Carton" && status=="none"){
                        status="carton";
                        PV.RPC("cartonRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Trashcan" && status!="none"){
                        status="none";
                        PV.RPC("trashcanRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                    }else if(hit.collider.transform.tag=="Da_ban_take" && status=="none"){
                        status="da_ban";
                        PV.RPC("da_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Da_ban" && status=="none"){
                        status="da_ban";
                        PV.RPC("da_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban" && status=="none"){
                        status="pai_ban";
                        PV.RPC("pai_banRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_take" && status=="da_ban"){
                        status="pai_ban";
                        PV.RPC("pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_blue" && status=="none"){
                        status="cloth1_pai_ban";
                        PV.RPC("cloth1_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="cloth1_pai_ban"){
                        status="cloth1_tailor";
                        PV.RPC("cloth1_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_tailor" && status=="none"){
                        status="cloth1_tailor";
                        PV.RPC("cloth1_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="cloth1_tailor"){
                        status="cloth1_done";
                        PV.RPC("cloth1_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth1_done" && status=="none"){
                        status="cloth1_done";
                        PV.RPC("cloth1_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_mix" && status=="none"){
                        status="clothmix_pai_ban";
                        PV.RPC("clothmix_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="clothmix_pai_ban"){
                        status="clothmix_tailor";
                        PV.RPC("clothmix_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Clothmix_tailor" && status=="none"){
                        status="clothmix_tailor";
                        PV.RPC("clothmix_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="clothmix_tailor"){
                        status="clothmix_done";
                        PV.RPC("clothmix_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Clothmix_done" && status=="none"){
                        status="clothmix_done";
                        PV.RPC("clothmix_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_green" && status=="none"){
                        status="cloth2_pai_ban";
                        PV.RPC("cloth2_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="cloth2_pai_ban"){
                        status="cloth2_tailor";
                        PV.RPC("cloth2_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_tailor" && status=="none"){
                        status="cloth2_tailor";
                        PV.RPC("cloth2_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="cloth2_tailor"){
                        status="cloth2_done";
                        PV.RPC("cloth2_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth2_done" && status=="none"){
                        status="cloth2_done";
                        PV.RPC("cloth2_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if((hit.collider.transform.tag=="blue" && status=="cloth4_red") || (hit.collider.transform.tag=="red" && status=="cloth4_blue")){
                    status="cloth4_purple";
                    PV.RPC("cloth4_purple_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_purple" && status=="none"){
                        status="cloth4_purple";
                        PV.RPC("cloth4_purpleRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if((hit.collider.transform.tag=="green" && status=="cloth3_red") || (hit.collider.transform.tag=="red" && status=="cloth3_green")){
                    status="cloth3_yello";
                    PV.RPC("cloth3_yello_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_yello" && status=="none"){
                        status="cloth3_yello";
                        PV.RPC("cloth3_yelloRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_yello" && status=="none"){
                        status="cloth3_pai_ban";
                        PV.RPC("cloth3_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="cloth3_pai_ban"){
                        status="cloth3_tailor";
                        PV.RPC("cloth3_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_tailor" && status=="none"){
                        status="cloth3_tailor";
                        PV.RPC("cloth3_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="cloth3_tailor"){
                        status="cloth3_done";
                        PV.RPC("cloth3_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth3_done" && status=="none"){
                        status="cloth3_done";
                        PV.RPC("cloth3_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_purple" && status=="none"){
                        status="cloth4_pai_ban";
                        PV.RPC("cloth4_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Tailor" && status=="cloth4_pai_ban"){
                        status="cloth4_tailor";
                        PV.RPC("cloth4_tailor_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_tailor" && status=="none"){
                        status="cloth4_tailor";
                        PV.RPC("cloth4_tailorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Car" && status=="cloth4_tailor"){
                        status="cloth4_done";
                        PV.RPC("cloth4_doneRPC", RpcTarget.AllBuffered,PlayerControl.ID,GOnumber);
                    }else if(hit.collider.transform.tag=="Cloth4_done" && status=="none"){
                        status="cloth4_done";
                        PV.RPC("cloth4_done_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Pai_ban_red" && status=="none"){
                        status="pai_ban_red";
                        PV.RPC("red_pai_ban_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name,GOnumber);
                    }else if(hit.collider.transform.tag=="Work" && status!="none"){
                        status="none";
                        PV.RPC("workRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.transform.position,hit.collider.transform.rotation,GOnumber);
                    }    
                }
            }
        }
        flag1=false;
        flag2=false;
        flag3=false;
        flag4=false;
        playerGOCollider.enabled=true;
    }
    [PunRPC]
    void cloth4_purple_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_purple;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_yello_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_yello;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_done_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_done,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_done_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_done,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_done_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_done,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_done_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_done,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_purpleRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_purple,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_yelloRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_yello,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_doneRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth1_done;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void clothmix_doneRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=clothmix_done;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_doneRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_done;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_doneRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_done;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_doneRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth2_done;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_tailorRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_tailor,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void clothmix_tailorRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(clothmix_tailor,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_tailorRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_tailor,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_tailorRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_tailor,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_tailorRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_tailor,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_tailor_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth1_tailor;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void clothmix_tailor_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=clothmix_tailor;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_tailor_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_tailor;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_tailor_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_tailor;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_tailor_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth2_tailor;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_pai_ban_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(pai_ban_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void red_pai_ban_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(pai_ban_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void clothmix_pai_ban_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(pai_ban_mix,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_pai_ban_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(pai_ban_yello,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_pai_ban_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(pai_ban_purple,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_pai_ban_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(pai_ban_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_pai_banRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(pai_ban_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void clothmix_pai_banRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(pai_ban_mix,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_pai_banRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(pai_ban_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_pai_banRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(pai_ban_yello,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_pai_banRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(pai_ban_purple,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void pai_ban_redRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(pai_ban_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void pai_ban_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=pai_ban;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void pai_banRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(pai_ban,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void da_banRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(da_ban,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void da_ban_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(da_ban,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1RPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2RPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3RPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4RPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void blueyeing1RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth1_blue;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void blueyeing2RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth2_blue;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void blueyeing3RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_blue;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void blueyeing4RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_blue;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void redyeing1RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth1_red;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void redyeing2RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth2_red;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void redyeing3RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_red;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void redyeing4RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_red;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void greenyeing1RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth1_green;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void greenyeing2RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth2_green;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void greenyeing3RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_green;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void greenyeing4RPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_green;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_blueRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_greenRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth1_redRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_blueRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_greenRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth2_redRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_blueRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_greenRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth3_redRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_blueRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_greenRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cloth4_redRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void clothmixRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(clothmix,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void clothmix_takeRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(clothmix,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void carton_takeRPC(int parentViewId,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(carton,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void cartonRPC(int parentViewId,string GOname,int GOnumber){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(carton,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+1.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void trashcanRPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
    }
    [PunRPC]
    void conveyorRPC(int parentViewId,Vector3 conveyorPosition,Quaternion conveyorRotation,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1"){
                insGO=cloth1_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2"){
                insGO=cloth2_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3"){
                insGO=cloth3_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4"){
                insGO=cloth4_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_blue"){
                insGO=cloth1_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_green"){
                insGO=cloth1_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_red"){
                insGO=cloth1_red_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_blue"){
                insGO=cloth2_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_green"){
                insGO=cloth2_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_red"){
                insGO=cloth2_red_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_blue"){
                insGO=cloth3_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_green"){
                insGO=cloth3_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_red"){
                insGO=cloth3_red_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_blue"){
                insGO=cloth4_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_green"){
                insGO=cloth4_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_red"){
                insGO=cloth4_red_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Clothmix"){
                insGO=clothmix_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Carton"){
                insGO=carton_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Da_ban"){
                insGO=da_ban_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban"){
                insGO=pai_ban_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_blue"){
                insGO=pai_ban_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_tailor"){
                insGO=cloth1_tailor_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_done"){
                insGO=cloth1_done_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_tailor"){
                insGO=cloth2_tailor_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_done"){
                insGO=cloth2_done_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_tailor"){
                insGO=cloth3_tailor_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_done"){
                insGO=cloth3_done_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_tailor"){
                insGO=cloth4_tailor_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_done"){
                insGO=cloth4_done_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_purple"){
                insGO=cloth4_purple_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_yello"){
                insGO=cloth3_yello_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_yello"){
                insGO=pai_ban_yello_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_green"){
                insGO=pai_ban_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_purple"){
                insGO=pai_ban_purple_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_red"){
                insGO=pai_ban_red_c;
            }
        }
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(conveyorPosition.x,conveyorPosition.y+0.1f,conveyorPosition.z) ,conveyorRotation);
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
    [PunRPC]
    void workRPC(int parentViewId,Vector3 conveyorPosition,Quaternion conveyorRotation,int GOnumber){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().childCount>1){
            if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1"){
                insGO=cloth1_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2"){
                insGO=cloth2_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3"){
                insGO=cloth3_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4"){
                insGO=cloth4_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_blue"){
                insGO=cloth1_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_green"){
                insGO=cloth1_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_red"){
                insGO=cloth1_red_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_blue"){
                insGO=cloth2_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_green"){
                insGO=cloth2_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_red"){
                insGO=cloth2_red_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_blue"){
                insGO=cloth3_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_green"){
                insGO=cloth3_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_red"){
                insGO=cloth3_red_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_blue"){
                insGO=cloth4_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_green"){
                insGO=cloth4_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_red"){
                insGO=cloth4_red_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Clothmix"){
                insGO=clothmix_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Carton"){
                insGO=carton_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Da_ban"){
                insGO=da_ban_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban"){
                insGO=pai_ban_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_blue"){
                insGO=pai_ban_blue_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_tailor"){
                insGO=cloth1_tailor_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_done"){
                insGO=cloth1_done_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_tailor"){
                insGO=cloth2_tailor_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_done"){
                insGO=cloth2_done_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_tailor"){
                insGO=cloth3_tailor_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_done"){
                insGO=cloth3_done_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_tailor"){
                insGO=cloth4_tailor_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_done"){
                insGO=cloth4_done_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_purple"){
                insGO=cloth4_purple_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_yello"){
                insGO=cloth3_yello_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_yello"){
                insGO=pai_ban_yello_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_green"){
                insGO=pai_ban_green_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_purple"){
                insGO=pai_ban_purple_c;
            }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Pai_ban_red"){
                insGO=pai_ban_red_c;
            }
        }
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(conveyorPosition.x,conveyorPosition.y+0.5f,conveyorPosition.z) ,conveyorRotation);
        takeGO.name=GOnumber.ToString();
        this.GOnumber+=1;
    }
}

