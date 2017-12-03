using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Monstre
{

    public GameObject bouleDeFeu;
    private float vitesseDuTir = 900f;
    private float cadenceDeTir = 1f;
    private float startTime;
   
    private bool faireFeu = true;
    public int compteurDeTir = 0;
	void Start()
    {
        base.Start();
        Debug.Log("un Dragon start");
        startTime = 0;
        
    }
	
	// Update is called once per frame


    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "personnage")
        {
            heroEstCibler = true;
        }
     
    }
    //GameObject projectile = (GameObject)
    private void cracherFeu()
    {
        faireFeu = false;
        compteurDeTir++;
        Vector2 chuLa = personnage.transform.position;
        Vector2 directBoule = bouleDeFeu.transform.localScale;
        if(difference < 0)
        {
            Instantiate(bouleDeFeu, new Vector2(this.transform.position.x - 1, this.transform.position.y), Quaternion.identity);
            directBoule.x *= -1;
        }
        else
        {
            Instantiate(bouleDeFeu, new Vector2(this.transform.position.x + 1, this.transform.position.y), Quaternion.identity);
            //directBoule.x *= -1;
        }
        Rigidbody2D body = bouleDeFeu.GetComponent<Rigidbody2D>();

        //projectile.transform.Translate(chuLa);
        body.AddForceAtPosition(Vector3.right * 1000, transform.position);
        //body.AddForce(this.transform.eulerAngles * vitesseDuTir);
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "personnage")
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

    void Update()
    {
        startTime += Time.deltaTime;
        if (heroEstCibler)
        {
            if (faireFeu)
                cracherFeu();
            else if (startTime >= cadenceDeTir)
            {
                startTime = 0;
                faireFeu = true;
            }
        }

    }
}
