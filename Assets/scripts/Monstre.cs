using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    protected GameObject personnage;
    protected Vector2 positonDuHero;
    public bool directionDroite = true, heroEstCibler = false, enCorpsACorps = false, retour = false;
    protected bool vaSiMords = false;
    protected float cadenceMorsure = 1.2f, startTime;
    public int vie = 1;
    public AudioSource sonCri, saMorsure;
    Vector3 scale;
    // personnage = ManegerDeGame.game.gameObject.GetComponent<GenerateurDeNiveaux>().joueur[0];
    // Use this for initialization
    protected void Start()
    {
        startTime = 0f;

        personnage = ManegerDeGame.game.gameObject.GetComponent<GenerateurDeNiveaux>().joueur[0];
        positonDuHero = personnage.transform.localPosition;
        scale = this.transform.localScale;
        scale *= -1;
        sonCri = this.GetComponent<AudioSource>();

    }

    
    private void mordrePersonnage()
    {
        ManegerDeGame.game.prendreDegat();
        saMorsure.Play();
        vaSiMords = false;
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "personnage")
        {
            personnage = obj.gameObject;
            heroEstCibler = true;
            sonCri.Play();
        }

        if(obj.gameObject.tag == "mur" || obj.gameObject.tag == "ennemi")
        {
            if (!retour)
                retour = true;
            else if(retour)
                retour = false;
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {

        if (obj.gameObject.tag == "personnage")
        {
            heroEstCibler = true;
            personnage = obj.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroEstCibler = false;
            personnage = null;
        }
    }
    // Update is called once per frame
    protected void Update()
    {
        personnage = ManegerDeGame.game.gameObject.GetComponent<GenerateurDeNiveaux>().joueur[0];
        
        positonDuHero = personnage.transform.localPosition;
        
        startTime += Time.deltaTime;

        if (enCorpsACorps)
        {
            if (vaSiMords)
                mordrePersonnage();
            else if (startTime >= cadenceMorsure)
            {
                startTime = 0;
                vaSiMords = true;
            }
        }

        if (heroEstCibler)
        {

           
            Quaternion rotation = Quaternion.LookRotation(personnage.transform.localPosition - this.transform.position);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 10000);
    
            //this.transform.rotation = Quaternion.Euler(, 0, 0, 0);
            if (rotation.x > 90)
            {
                transform.Rotate(0, 180, 0, 0);
            }

            else
            {
                transform.Rotate(0, 240, 0, 0);
            }
        }  

         if (vie <= 0)
            Destroy(this.gameObject);
    }


    public void perdreVie()
    {
        vie--;
    }


}