﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueExplosive : MonoBehaviour {
     public bool recharger = true;
     public bool detonation = false;
     public bool quelquunDedans = false;
     private bool changementAFaire = false;
     private float delait = 0;
     private int interval = 3;
     public Renderer image;
     AudioSource kaboum;
 	// Use this for initialization
 	void Start ()
     {
         kaboum = this.GetComponent<AudioSource>();
		//couleurHero = this.gameObject.GetComponentInParent<SpriteRenderer>();
 	}
 	
     void OnTriggerEnter2D(Collider2D ennemi)
     {
         if(ennemi.gameObject.tag == "Ennemi")
         {
             quelquunDedans = true;
             if (recharger && detonation)
             {
                 Destroy(ennemi.gameObject);
                 recharger = false;
                 detonation = false;
                 kaboum.Play();
             }
         }
     }
     void OnTriggerStay2D(Collider2D ennemi)
     {
         if (ennemi.gameObject.tag == "Ennemi")
         {
             quelquunDedans = true;
             if (recharger && detonation)
             {
                 Destroy(ennemi.gameObject);
                 recharger = false;
                 detonation = false;
                 kaboum.Play();
                 image.sortingOrder = -1;
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
         if (recharger && detonation)
             image.sortingOrder = 1;

         delait  += Time.deltaTime;
 
         if (!recharger)
         {
             if (changementAFaire)
             { }  //changementDeCouleur();
             else if (delait > interval)
             {
                 changementAFaire = true;
                 delait = 0;
             }
         }
    
 	}
 
     void FixedUpdate()
     {
         if (Input.GetKey(KeyCode.Space) && !detonation && recharger)
         {
             detonation = true;

         }
         
 
     }
 
     /*private void changementDeCouleur()
     {
         if (detonation)
             couleurHero.material.color = Color.black;
         else if (couleurHero.material.color == Color.black)
             couleurHero.material.color = Color.yellow;
         else
         {
             couleurHero.material.color = Color.white;
             recharger = true;
         }
 
         changementAFaire = false;
     }*/
 
    
 }
  
