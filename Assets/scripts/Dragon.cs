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
        
	}
	
	// Update is called once per frame


    void OnTriggerEnter(Collider obj)
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
        
         GameObject projectile = Instantiate(bouleDeFeu, this.transform.position, Quaternion.identity);
         Rigidbody body = projectile.GetComponent<Rigidbody>();

         body.AddForce(this.transform.forward * vitesseDuTir);
    }

    void OnTriggerStay(Collider obj)
    {
        if(obj.gameObject.tag == "personnage")
        {
            heroEstCibler = true;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == "personnage")
        {
            heroEstCibler = false;
        }
    }

    void Update()
    {
        startTime = Time.deltaTime;
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
