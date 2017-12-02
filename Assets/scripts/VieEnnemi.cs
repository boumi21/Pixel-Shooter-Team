using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieEnnemi : MonoBehaviour
{
    public int vie = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vie <= 0)
            Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "BouleFeu")
            perdreVie();

        //Destroy(this.gameObject);
    }
    void perdreVie()
    {
        vie--;
    }

}