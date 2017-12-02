﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleProjectile : MonoBehaviour
{
 
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "BouleFeu")
            collider.SendMessage("perdreVie");

        Destroy(this.gameObject);
    }
}