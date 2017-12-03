using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    protected GameObject personnage;
    public bool directionDroite = true;
    public bool heroEstCibler = false;
    public float posMonstre = 0;
    public float posPerso = 0;
    public float difference = 0;
    public int vie = 1;
    public AudioSource sonCri;
    Vector3 scale;
    // Use this for initialization
    protected void Start()
    {
        personnage = GameObject.Find("Personnage");
        scale = this.transform.localScale;
        scale *= -1;
       sonCri = this.GetComponent<AudioSource>();
       posMonstre = this.transform.position.x;
       posPerso = personnage.transform.position.x;
       //difference = posMonstre - posPerso;
      
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "personnage")
        {
            heroEstCibler = true;
            sonCri.Play();
            posMonstre = this.transform.position.x;
            posPerso = personnage.transform.position.x;
            //difference = posMonstre - posPerso;
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {

        if (obj.gameObject.tag == "personnage")
        {
            heroEstCibler = true;

            posMonstre = this.transform.position.x;
            posPerso = personnage.transform.position.x;
            //difference = posMonstre - posPerso;
        }
    }
    // Update is called once per frame
    protected void Update()
    {
        if (heroEstCibler)
        {
            Quaternion rotation = Quaternion.LookRotation(personnage.transform.position - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 10000);
           
            if (rotation.x > 90)
                this.transform.rotation = new Quaternion(0, 180, 0, 0);
            else
                this.transform.rotation = new Quaternion(0,0,0,0);
           

        }
        if (posMonstre > posPerso)
            directionDroite = false;

        if(!directionDroite)
            tourne();           
        
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
            scale.x *= -1;        
    }

}