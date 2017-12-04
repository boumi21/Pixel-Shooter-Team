using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueExplosive : MonoBehaviour 
{
    public bool recharger = true;
    public bool detonation = true;
    private bool changementAFaire = false;
    private float delait = 0;
    private int interval = 3;
    GameObject leHero;
    Renderer couleurHero;
	// Use this for initialization
	void Start ()
    {
        leHero = GameObject.Find("Personnage");
        couleurHero = leHero.GetComponent<Renderer>();
	}
	
    void OnTriggerStay2D(Collider2D ennemi)
    {
        if(ennemi.gameObject.tag == "Ennemi")
        {
            if (recharger && detonation)
            {
                Destroy(ennemi.gameObject);
                recharger = false;
                detonation = false;
            }
        }
    }
	// Update is called once per frame
	void Update () 
    {
        delait  += Time.deltaTime;

        if (!recharger)
        {
            if (changementAFaire)
                changementDeCouleur();
            else if(delait > interval)
            {
                changementAFaire = true;
                delait = 0;
            }
        }
   
	}

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && !detonation)
            detonation = true;
        

    }

    private void changementDeCouleur()
    {
        if (couleurHero.material.color == Color.white)
            couleurHero.material.color = Color.black;
        else if (couleurHero.material.color == Color.black)
            couleurHero.material.color = Color.yellow;
        else
        {
            couleurHero.material.color = Color.white;
            recharger = true;
        }

        changementAFaire = false;
    }

   
}
