using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnnemi : MonoBehaviour
{
    public float vitesseDeDeplacement = 100f;
    Rigidbody2D leCorps;
    // Use this for initialization
    void Start()
    {
        leCorps = this.GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {

    }
}