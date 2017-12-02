using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleProjectile : MonoBehaviour
{
    public LayerMask cible;
    // Use this for initialization
    void Start()
    {
        // Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Ennemi")
        {
            obj.SendMessage("perdreVie");
            Destroy(this.gameObject);
        }



    }
}