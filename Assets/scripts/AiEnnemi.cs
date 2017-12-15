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
    Vector2 ennemiDepart, ennemiDirection, personnagePosition;    
    public bool heroCibler = false;
    public System.Random hasard;
    public float startTime, vitesseDeDeplacement = 133.25f;

    // Use this for initialization 
    void Start()
    {
        
        hasard = new System.Random();
        personnagePosition = (Vector2)personnage.transform.position;
        ennemiDepart = (Vector2)monstre.transform.position;
        Instantiate(patrouille[1], ennemiDepart, Quaternion.identity);
        positionPointArrivee();  
        startTime = 0f;
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
        personnagePosition = (Vector2)personnage.transform.position;
        patrouille[0].transform.position = ennemiDirection;
        patrouille[1].transform.position = ennemiDepart;

        if(!heroCibler)
        {
            if (pointASuivre < patrouille.Length)
            {
                GameObject pointVisee;
                pointVisee = patrouille[pointASuivre];
                Vector2 cible = (Vector2)pointVisee.transform.position;
                Debug.Log("départ" + ennemiDepart.x + " et " + ennemiDepart.y);
                Debug.Log("arrivé" + ennemiDirection.x + " et " + ennemiDirection.y);
                Vector2 moveDirection = cible - (Vector2)transform.position;
                Vector2 velocity = leCorps.velocity;

                if (moveDirection.magnitude < .1)
                {
                    pointASuivre++;
                }
                else
                {
                    velocity = moveDirection.normalized * vitesseDeDeplacement;
                    
                }

                leCorps.MovePosition(leCorps.position + velocity * Time.fixedDeltaTime);
            }
            else
            {
                pointASuivre = 0;
            }
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

        ennemiDirection = (Vector2)this.transform.position;
        ennemiDirection += voixPrise;
        
        Instantiate(patrouille[0],ennemiDirection, Quaternion.identity);
        //Ray2D myRay = new Ray2D(pointDepart.transform.localPosition, pointArrivee.transform.position);
        
       //Physics2D.Raycast(myRay);      
        
    }
    
    public void enAvantMarche(GameObject pointASuivre)
    {
        GameObject pointVisee;
        pointVisee = personnage;
        Vector2 cible = (Vector2)pointVisee.transform.position;
        Debug.Log("départ" + ennemiDepart.x + " et " + ennemiDepart.y);
        Debug.Log("arrivé" + ennemiDirection.x + " et " + ennemiDirection.y);
        Vector2 moveDirection = cible - (Vector2)transform.position;
        Vector2 velocity = leCorps.velocity;

        velocity = moveDirection.normalized * vitesseDeDeplacement;

        leCorps.MovePosition(leCorps.position + velocity * Time.fixedDeltaTime);

    }
   
  
}