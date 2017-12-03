using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleProjectile : MonoBehaviour
{
    public bool touche = false;
    // Use this for initialization
    void Start()
    {       
        Destroy(this.gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "personnage")
        {
            Debug.Log("j'ai hit le gars !");
            touche = true;
            //ManegerDeGame.game.prendreDegat();
            Destroy(this.gameObject);
            
        }
        
    }

}