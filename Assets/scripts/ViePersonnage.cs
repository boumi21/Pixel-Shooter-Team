using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViePersonnage : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ennemi")
		{
			ManegerDeGame.game.prendreDegat ();

			attendre ();
		}
	}
	IEnumerable attendre()
	{
		yield return new WaitForSeconds (2);
	}

}