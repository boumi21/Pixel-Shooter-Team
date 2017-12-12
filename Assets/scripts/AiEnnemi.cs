using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AiEnnemi : MonoBehaviour
{
    public float vitesseDeDeplacement = 100f;
    public GameObject pointDepart;
    public GameObject pointArrivee;
    public GameObject personnage;
    Rigidbody2D leCorps;
    Vector2 ennemiDepart;
    Vector2 ennemiDirection;
    Vector2 positionASuivre;
    public bool heroCibler = false;
    public System.Random hasard;
    public float vitesseDeplacement = 5f;
    public float cadenceDeTir = 3f;
    public bool faireFeu = true;
    public float startTime;
    

    // Use this for initialization 
    void Start()
    {
        hasard = new System.Random();
        ennemiDepart = this.transform.position;
        Instantiate(pointDepart, ennemiDepart, Quaternion.identity);
        positionPointArrivee();   

        startTime = 0f;
        ennemiDepart = new Vector2(this.transform.position.x, this.transform.position.y);
        ennemiDirection = new Vector2(ennemiDepart.x, ennemiDepart.y+6);
        leCorps = this.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroCibler = true;
            positionASuivre = obj.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroCibler = true;
            positionASuivre = obj.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroCibler = false;
            positionASuivre = ennemiDirection;
        }
    }
    // Update is called once per frame
    void Update()
    {
        startTime = Time.deltaTime;

        if(!heroCibler)
        {
            enAvantMarche();
        }
        else if(heroCibler)
        {
            if (faireFeu)
            {
                Debug.Log("vais je tirer?");
            }
            else if (startTime >= cadenceDeTir)
            {
                startTime = 0;
                faireFeu = true;
            }
            
           // positionASuivre = 
            //enAvantMarche();
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

        ennemiDirection = this.transform.position;
        ennemiDirection += voixPrise;
        
        Instantiate(pointArrivee,ennemiDirection, Quaternion.identity);
        Ray2D myRay = new Ray2D(pointDepart.transform.position, pointArrivee.transform.position);

       // Physics2D.Raycast(myRay);

        
        
    }
    
    public void enAvantMarche()
    {
        
    }
   
  
}