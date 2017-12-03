using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BougerWASD : MonoBehaviour {
	
	public float vitesse = 10;
	public float maxSpeed = 5;
	[HideInInspector]public GameObject joueur;
	private Rigidbody2D body;
	private float vitesseCourante = 0;

	void Start()
	{
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

	}
}