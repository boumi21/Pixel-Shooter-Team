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
        base.Start();
        Debug.Log("un Dragon start");
        startTime = 0;
        
    }
	
	// Update is called once per frame



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
        body.AddForce(Vector3.right * 1000);
        
        //body.AddForce(this.transform.eulerAngles * vitesseDuTir);
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
