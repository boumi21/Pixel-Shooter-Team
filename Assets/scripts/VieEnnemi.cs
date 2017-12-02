using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieEnnemi : MonoBehaviour
{
	public int vie = 1;
	// Use this for initialization
	void Start ()
	{
		if (this.gameObject.tag == "Dragon")
			this.vie += 3;
		else if (this.gameObject.tag == "LimaceVerte")
			this.vie++;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (vie <= 0)
			Destroy (this.gameObject);
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "BouleFeu")
            perdreVie();
       
        Destroy(this);
    }
	public void perdreVie()
	{
		vie--;
	}

}
