using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    public GameObject personnage;
    public bool directionDroite = true;
    protected bool heroEstCibler = false;
    public float posMonstre = 0;
    public float posPerso = 0;
    public float difference = 0;
    public int vie = 1;
    // Use this for initialization
    protected void Start()
    {
        Debug.Log("VieEnnemi Start");
        posMonstre = this.transform.position.x;
        posPerso = personnage.transform.position.x;
        difference = posMonstre - posPerso;
      
    }

    void OnTriggerCollider2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "personnage")
        {
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
 
    public void perdreVie()
    {
        vie--;
    }

    void tourne()
    {
        Vector3 scale = this.transform.localScale;

        scale.x *= -1;
    }

}