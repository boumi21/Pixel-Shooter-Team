using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CracherBouleDeFeu : MonoBehaviour
{
    //public AiEnnemi aiEnnemi;
    public GameObject personnage, bouleDeFeu;
    public float cadenceDeTir = 3f, startTime, vitesseDuTir = 400f;
    public bool faireFeu = false;
    //public bool heroCibler = false;
	// Use this for initialization
	void Start ()
    {
        startTime = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
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
        }       
		
	}

    public void cracherFeu()
    {
        faireFeu = false;
        GameObject projectile = Instantiate(bouleDeFeu, this.transform.position, Quaternion.identity);
        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();
        Debug.Log("j'ai craché!!");
        body.velocity = personnage.transform.position;
        body.AddForce(personnage.transform.position * vitesseDuTir);
        //body.AddForceAtPosition(transform.tra * cadenceDeTir);
    }
}
