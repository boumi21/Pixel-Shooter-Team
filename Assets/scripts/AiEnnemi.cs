using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Permets au monstre de se mouvoir et suivre le personnage quand il est à porter.
/// </summary>
public class AiEnnemi : MonoBehaviour
{

    public GameObject[] patrouille;
    public int pointASuivre = 0;
    public GameObject personnage;
    public GameObject monstre;
    Rigidbody2D leCorps;
    Vector2 ennemiDepart, ennemiDirection;    
    public bool heroCibler = false;
    public System.Random hasard;
    public float startTime, vitesseDeDeplacement = .25f;

    // Use this for initialization 
    void Start()
    {
        hasard = new System.Random();
        ennemiDepart = this.transform.position;
        Instantiate(patrouille[0], ennemiDepart, Quaternion.identity);
        positionPointArrivee();  
        startTime = 0f;
        //ennemiDepart = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);
        //ennemiDirection = new Vector2(ennemiDepart.x, ennemiDepart.y+6);
        leCorps = monstre.GetComponent<Rigidbody2D>();
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
            if (pointASuivre < patrouille.Length)
            {
                GameObject pointVisee;
                pointVisee = patrouille[pointASuivre];
                //bool retour = GetComponentInParent<Monstre>().retour;
                Vector2 cible = pointVisee.transform.position;
                //Vector3 monstrePosition = this.transform.position;
                Vector2 moveDirection = cible - (Vector2)transform.position;
                Vector2 velocity = leCorps.velocity;

                if (moveDirection.magnitude < 1)
                {
                    pointASuivre++;
                }
                else
                {
                    velocity = moveDirection.normalized * vitesseDeDeplacement;
                }

                leCorps.velocity = velocity;
            }
            else
            {
                //pointASuivre = 0;
            }
        }
        else if(heroCibler)
        {
           // enAvantMarche(personnage);            
        }

    }
 
    public void positionPointArrivee()
    {
        int direction = hasard.Next(0, 4);  
        Vector2 voixPrise = new Vector2();
        int ajout = 3;
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

        ennemiDirection = this.transform.position;
        ennemiDirection += voixPrise;
        
        Instantiate(patrouille[1],ennemiDirection, Quaternion.identity);
        //Ray2D myRay = new Ray2D(pointDepart.transform.localPosition, pointArrivee.transform.position);
        
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
        if(moveDirection.magnitude < 0)
        {
            if (retour)
                GetComponentInParent<Monstre>().retour = false;
            else if(!retour)
                GetComponentInParent<Monstre>().retour = true;
        }
        else
        {
            velocity = moveDirection.normalized * vitesseDeDeplacement;
        }        

        leCorps.velocity = velocity;

    }
   
  
}