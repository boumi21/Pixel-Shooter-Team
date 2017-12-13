﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Permets au monstre de se mouvoir et suivre le personnage quand il est à porter.
/// </summary>
public class AiEnnemi : MonoBehaviour
{

    public GameObject pointDepart, pointArrivee, personnage;
    Rigidbody2D leCorps;
    Vector2 ennemiDepart, ennemiDirection;    
    public bool heroCibler = false;
    public System.Random hasard;
    public float cadenceDeTir = 3f,startTime, vitesseDeDeplacement = 1.5f;

    // Use this for initialization 
    void Start()
    {
        hasard = new System.Random();
        ennemiDepart = this.transform.localPosition;
        Instantiate(pointDepart, ennemiDepart, Quaternion.identity);
        positionPointArrivee();   

        startTime = 0f;
        ennemiDepart = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);
        ennemiDirection = new Vector2(ennemiDepart.x, ennemiDepart.y+6);
        leCorps = GetComponentInParent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroCibler = true;            
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroCibler = true;            
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroCibler = false;            
        }
    }
    // Update is called once per frame
    void Update()
    {        
        startTime = Time.deltaTime;

        if(!heroCibler)
        {
            if (!GetComponentInParent<Monstre>().retour)
                enAvantMarche(pointArrivee);
            else if (GetComponentInParent<Monstre>().retour)
                enAvantMarche(pointDepart);
        }
        else if(heroCibler)
        {
            enAvantMarche(personnage);            
        }

    }
 
    public void positionPointArrivee()
    {
        int direction = hasard.Next(0, 4);  
        Vector2 voixPrise = new Vector2();
        int ajout = 6;
        switch(direction)
        {
            case 0:
                voixPrise = new Vector2(0, ajout);
                break;
            case 1:
                voixPrise = new Vector2(0, -ajout);
                break;
            case 2:
                voixPrise = new Vector2(ajout, 0);
                break;
            case 3:
                voixPrise = new Vector2(-ajout, 0);
                break;
        }

        ennemiDirection = this.transform.localPosition;
        ennemiDirection += voixPrise;
        
        Instantiate(pointArrivee,ennemiDirection, Quaternion.identity);
        Ray2D myRay = new Ray2D(pointDepart.transform.localPosition, pointArrivee.transform.position);
        
       //Physics2D.Raycast(myRay);      
        
    }
    
    public void enAvantMarche(GameObject pointASuivre)
    {
         //= point;
        bool retour = GetComponentInParent<Monstre>().retour;
        Vector3 cible = pointASuivre.transform.position;
        //Vector3 monstrePosition = this.transform.position;
        Vector3 moveDirection = cible - this.transform.position;
        Vector3 velocity = leCorps.velocity;
        if(moveDirection.magnitude < .1)
        {
            if (retour)
                GetComponentInParent<Monstre>().retour = false;
            else if(!retour)
                GetComponentInParent<Monstre>().retour = true;
        }
        else
        {
            velocity = moveDirection.normalized;
        }        

        leCorps.velocity = velocity;

    }
   
  
}