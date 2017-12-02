using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Monstre
{
    public GameObject personnage;
    public bool heroEstCibler = false;
    public GameObject bouleDeFeu;
    private float vitesseDuTir = 400f;
    private float cadenceDeTir = 3f;
    private float startTime;
    private bool faireFeu = true;
	void Start()
    {
        base.Start();
        Debug.Log("un Dragon start");
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        startTime = Time.deltaTime;
        if(heroEstCibler)
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

    void OnTriggerEnter(Collider obj)
    {
        if(obj == personnage)
        {
            heroEstCibler = true;
        }
            
        
    }

    private void cracherFeu()
    {
        faireFeu = false;

        Rigidbody body = bouleDeFeu.GetComponent<Rigidbody>();
         Instantiate(bouleDeFeu, this.transform.position, Quaternion.identity);

         body.AddForce(this.transform.forward * vitesseDuTir);
    }

    void OnTriggerStay(Collider obj)
    {

    }
}
