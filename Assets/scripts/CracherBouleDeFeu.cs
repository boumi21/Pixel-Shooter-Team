using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CracherBouleDeFeu : MonoBehaviour
{
    public AiEnnemi aiEnnemi;
    public GameObject boucheDragon;
    public GameObject bouleDeFeu;
    public float cadenceDeTir = 3f;
    public bool faireFeu = true;
    public float startTime;
    //public bool heroCibler = false;
	// Use this for initialization
	void Start ()
    {
        startTime = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
       // heroCibler = GetComponent<AiEnnemi>().heroCibler; 
        /*
        if(!GetComponent<AiEnnemi>().heroCibler)
        {
            positionASuivre = ennemiDirection;
            enAvantMarche();
        }
        else 
            */
        if (GetComponent<AiEnnemi>().heroCibler)
        {
            if (faireFeu)
            {
                Debug.Log("vais je tirer?");
                cracherFeu();
            }
            else if (startTime >= cadenceDeTir)
            {
                startTime = 0;
                faireFeu = true;
            }

            // positionASuivre = 
            //enAvantMarche();
        }
       
		
	}

    public void cracherFeu()
    {
        faireFeu = false;
        GameObject projectile = (GameObject)Instantiate(bouleDeFeu, this.transform.position, Quaternion.identity);

        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();
        Debug.Log("j'ai craché!!");
       // body.velocity = this.GetComponent<AiEnnemi>.positionASuivre;
        //body.AddForce(transform.forward * vitesseDuTir);
        //body.AddForceAtPosition(transform.tra * cadenceDeTir);
    }
}
