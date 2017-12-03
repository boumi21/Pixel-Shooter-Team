using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Monstre
{

    public GameObject bouleDeFeu;
    private float vitesseDuTir = 900f;
    private float cadenceDeTir = 3f;
    private float startTime;
   
    private bool faireFeu = false;
    public int compteurDeTir = 0;
	void Start()
    {
        Vector3 chuLa = personnage.transform.position;
        Instantiate(bouleDeFeu, chuLa, Quaternion.identity);
        base.Start();
        //Debug.Log("un Dragon start");
        startTime = 0;
        
    }
	
	// Update is called once per frame



   
    private void cracherFeu()
    {
        faireFeu = false;
        //compteurDeTir++;
        Vector2 chuLa = personnage.transform.position;
        Vector2 directBoule = bouleDeFeu.transform.localScale;
   
        GameObject projectile = (GameObject)Instantiate(bouleDeFeu,chuLa, Quaternion.identity);
        directBoule.x *= -1;
        //new Vector2(this.transform.position.x - 2, this.transform.position.y)

      /*  else
        {
            Instantiate(bouleDeFeu, new Vector2(this.transform.position.x + 1, this.transform.position.y), Quaternion.identity);
            //directBoule.x *= -1;
        }*/
        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();

        //bouleDeFeu.transform.Translate(chuLa, Space.Self);
        body.AddForce(this.transform.forward * vitesseDuTir);
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
