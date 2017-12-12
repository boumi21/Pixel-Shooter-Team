﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnnemi : MonoBehaviour
{
    public float vitesseDeDeplacement = 100f;
    
    Rigidbody2D leCorps;
    Vector2 ennemiDepart;
    Vector2 ennemiDirection;
    Vector2 positionASuivre;
    public bool heroCibler = false;
    
    public float vitesseDeplacement = 5f;
    public float cadenceDeTir = 3f;
    public bool faireFeu = true;
    public float startTime;

    // Use this for initialization
    void Start()
    {
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
        if(!heroCibler)
        {
            positionASuivre = ennemiDirection;
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
            enAvantMarche();
        }

    }

    public void enAvantMarche()
    {
        if (this.transform.position.y <= ennemiDepart.y)
        {

        }
        else if (this.transform.position.x >= ennemiDepart.x)
        {

        }
    }

  
}