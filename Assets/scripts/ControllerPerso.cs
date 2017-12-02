using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPerso : MonoBehaviour {

	public static float vitesse = 5f;
	private Rigidbody body;
	//private List<Noeud> pathPoint;
	public GameObject controller;

	void Start () 
	{
		body = GetComponent<Rigidbody>();
	}
	

	/*void FixedUpdate () 
	{
		pathPoint = controller.GetComponent<Grille>().chemin;
		Vector3 target = pathPoint[0].position;
		Vector3 moveDirection = target - this.transform.position;
		Vector3 velocity = body.velocity;

		print(moveDirection.ToString());

		if (moveDirection.magnitude < .1)
			velocity = new Vector3(0f, 0f, 0f);
		else
			velocity = moveDirection.normalized * vitesse;
		body.velocity = velocity;
	}*/
}
