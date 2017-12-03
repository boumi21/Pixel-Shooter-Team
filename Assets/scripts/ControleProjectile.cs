using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleProjectile : MonoBehaviour
{
 
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "personnage")
        {
            collider.GetComponent<Monstre>().perdreVie();
            Destroy(this.gameObject);
        }

            

       
    }
}