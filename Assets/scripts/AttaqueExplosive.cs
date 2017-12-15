﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueExplosive : MonoBehaviour
{     
     public bool recharger = true,detonation = false,quelquunDedans = false;     
     public float delait = 0;
     private int interval = 5;
     public Renderer image;
     AudioSource kaboum;
 	// Use this for initialization
 	void Start ()
     {
         kaboum = this.GetComponent<AudioSource>();
 	}
 	
     void OnTriggerEnter2D(Collider2D ennemi)
     {
         if(ennemi.gameObject.tag == "Ennemi")
         {
             quelquunDedans = true;

             if (recharger && !detonation)
             {
                 if (Input.GetKey(KeyCode.Space))
                 {
                     Destroy(ennemi.gameObject);
                     recharger = false;
                     detonation = true;
                     kaboum.Play();
                     image.enabled = false;
                 }

             }
         }
     }
     void OnTriggerStay2D(Collider2D ennemi)
     {
         if (ennemi.gameObject.tag == "Ennemi")
         {
             quelquunDedans = true;

             if (recharger && !detonation)
             {
                 if(Input.GetKey(KeyCode.Space))
                 {
                     Destroy(ennemi.gameObject);
                     recharger = false;
                     detonation = true;
                     kaboum.Play();
                     image.enabled = false;
                 }
             
             }
         }
     }
     void OnTriggerExit2D(Collider2D ennemi)
     {
         if(ennemi.gameObject.tag == "Ennemi")
             quelquunDedans = false;
     }
 	// Update is called once per frame
 	void Update () 
     {
         if (recharger)
             image.enabled = true;

         delait  += Time.deltaTime;
 
         if (!recharger)
         {
             if (detonation)
             {
                 delait = 0;
                 detonation = false;
             }
             else if (delait > interval)
             {
                 recharger = true;
             }
         }
    
 	} 
    
 }
  
