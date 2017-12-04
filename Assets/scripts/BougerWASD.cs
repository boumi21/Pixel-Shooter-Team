using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BougerWASD : MonoBehaviour {
	
	public float vitesse = 10;
	public float maxSpeed = 5;
	[HideInInspector]public GameObject joueur;
	private Rigidbody2D body;
	private float vitesseCourante = 0;
	private Animator animateur;
	private bool flip = false;

	void Start()
	{
		Vector3 scale = this.transform.localScale;
		animateur = this.gameObject.GetComponent<Animator> ();
		joueur = this.gameObject;
		body = joueur.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		Vector3 velocity = body.velocity;

		if (Input.GetKey (KeyCode.D)) {
			if (vitesseCourante < vitesse)
				vitesseCourante++;
			velocity = new Vector3 (vitesseCourante, 0, 0);
		} else if (Input.GetKey (KeyCode.W)) {
			if (vitesseCourante < vitesse)
				vitesseCourante++;
			velocity = new Vector3 (0, vitesseCourante, 0);
		} else if (Input.GetKey (KeyCode.A)) {
			if (vitesseCourante > vitesse * -1f)
				vitesseCourante--;
			velocity = new Vector3 (vitesseCourante, 0, 0);
		} else if (Input.GetKey (KeyCode.S)) {
			if (vitesseCourante > vitesse * -1f)
				vitesseCourante--;
			velocity = new Vector3 (0, vitesseCourante, 0);
		} 
		else 
		{
			vitesseCourante = 0;
			velocity = new Vector3 (0, 0, 0);
		}
		print (body.velocity.x);
		body.velocity = velocity;
		animateur.SetFloat ("HS", body.velocity.x);
		animateur.SetFloat ("VS", body.velocity.y);
	}

	void Update()
	{
		/*print ("esfd");
		animateur.SetFloat ("HS", body.velocity.x);
		animateur.SetFloat ("VS", body.velocity.y);
		if (body.velocity.x < 0 && !flip) {
			scale = new Vector3 (scale.x * -1, scale.y, scale.z); 
			this.transform.localScale = scale;
			flip = true;
		} else if (body.velocity.x > -1 && flip) {
			scale = new Vector3 (scale.x * -1, scale.y, scale.z); 
			this.transform.localScale = scale;
			flip = false;
		}*/
		if (body.velocity.x < 0 && !flip) {
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			flip = true;
		} else if (body.velocity.x > -1 && flip) {
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			flip = false;
		}
	}

}