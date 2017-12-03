using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "personnage")
		{
			ManegerDeGame.game.gagnerPoints ();
			Destroy (this.gameObject);
		}
	}
}
