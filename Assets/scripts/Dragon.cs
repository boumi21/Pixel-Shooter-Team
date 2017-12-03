using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Monstre
{

    public GameObject bouleDeFeu;
    private float vitesseDuTir = 900f;
    private float cadenceDeTir = 3f;
    private bool faireFeu = false;
 
	void Start()
    {
        base.Start();
       
        Debug.Log("un Dragon start");
    }
	
	// Update is called once per frame
   
    public void cracherFeu()
    {
        faireFeu = false;
        GameObject projectile = (GameObject)Instantiate(bouleDeFeu, this.transform.position, Quaternion.identity);
        
        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();
        Debug.Log("j'ai craché!!");
        body.AddForce(this.transform.forward * vitesseDuTir);
    }

    void Update()
    {
        base.Update();

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
