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

        personnage = GameObject.Find("Personnage");
        positonDuHero = personnage.transform.position;
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
        //personnage = ManegerDeGame.game.gameObject.GetComponent<GenerateurDeNiveaux>().joueur[0];
        personnage = GameObject.Find("Personnage");
        positonDuHero = personnage.transform.position;
        
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
            print("il est cibler !");
            Quaternion rotation = Quaternion.LookRotation(personnage.transform.position - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 10000);
           
            if (rotation.x > 90)
            {
                print("j'ai passé dans rotation > 90");
                this.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
                
            else
            {
                print("j'ai passé dans else");
                this.transform.rotation = new Quaternion(0, 0, 0, 0);           

            }

        }      

        if(!directionDroite)
            tourne();           
        
         if (vie <= 0)
            Destroy(this.gameObject);
    }


    public void perdreVie()
    {
        vie--;
    }

    protected void tourne()
    {       
            scale.x *= -1;        
    }

}