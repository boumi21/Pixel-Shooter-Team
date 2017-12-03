using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    protected GameObject personnage;
    protected Vector3 positonDuHero;
    public bool directionDroite = true;
    public bool heroEstCibler = false;
    public bool enCorpsACorps = false;
    protected bool vaSiMords = false;
    protected float cadenceMorsure = 1.2f;
    protected float startTime;
    public int vie = 1;
    public AudioSource sonCri;
    public AudioSource saMorsure;
    Vector3 scale;
    // personnage = ManegerDeGame.game.gameObject.GetComponent<GenerateurDeNiveaux>().joueur[0];
    // Use this for initialization
    protected void Start()
    {
        startTime = 0f;

        personnage = personnage = ManegerDeGame.game.gameObject.GetComponent<GenerateurDeNiveaux>().joueur[0];
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
            heroEstCibler = true;
            sonCri.Play();
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {

        if (obj.gameObject.tag == "personnage")
        {
            heroEstCibler = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroEstCibler = false;
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
            Debug.Log("il est ciblé!");

           
            Quaternion rotation = Quaternion.LookRotation(personnage.transform.localPosition - this.transform.position);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 10000);
    
            //this.transform.rotation = Quaternion.Euler(, 0, 0, 0);
            
            Debug.Log("voici la valeur de x " + rotation.x);
            if (rotation.x > 90)
            {
                Debug.Log("j'ai passé dans rotation > 90");
                transform.Rotate(0, 180, 0, 0);
            }

            else
            {
                Debug.Log("j'ai passé dans else");
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