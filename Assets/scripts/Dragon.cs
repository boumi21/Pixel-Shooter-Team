using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Monstre
{
    public GameObject personnage;
    public bool heroEstCibler = false;
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

    private void cracherFeu()
    {
        faireFeu = false;
        compteurDeTir++;
        Vector2 chuLa = personnage.transform.position;
        GameObject projectile = (GameObject)Instantiate(bouleDeFeu, this.transform.position, Quaternion.identity);
        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();

        body.AddForceAtPosition(this.transform.up, chuLa);
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
            Quaternion rotation = Quaternion.LookRotation(personnage.transform.position - this.transform.position);

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
