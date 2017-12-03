﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    public GameObject personnage;
    public bool directionDroite = true;
    public bool heroEstCibler = false;
    public float posMonstre = 0;
    public float posPerso = 0;
    public float difference = 0;
    public int vie = 1;
    public AudioSource sonCri;
    // Use this for initialization
    protected void Start()
    {
       sonCri = this.GetComponent<AudioSource>();
       posMonstre = this.transform.position.x;
       posPerso = personnage.transform.position.x;
       difference = posMonstre - posPerso;
      
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "personnage")
        {
            heroEstCibler = true;
            sonCri.Play();
            posMonstre = this.transform.position.x;
            posPerso = personnage.transform.position.x;
            difference = posMonstre - posPerso;
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {

        if (obj.gameObject.tag == "personnage")
        {
            heroEstCibler = true;

            posMonstre = this.transform.position.x;
            posPerso = personnage.transform.position.x;
            difference = posMonstre - posPerso;
        }
    }
    // Update is called once per frame
    protected void Update()
    {
        if (difference < 0)
            directionDroite = false;

        if(!directionDroite)
        {
            tourne();
            directionDroite = true;
        }
         if (vie <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroEstCibler = false;
        }
    }
    public void perdreVie()
    {
        vie--;
    }

    void tourne()
    {
        Vector3 scale = this.transform.localScale;
        if (!directionDroite && heroEstCibler)
        {
            scale.x *= -1;
        }
    }

}