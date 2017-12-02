using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    
    public int vie = 1;
    // Use this for initialization
    protected void Start()
    {
        Debug.Log("VieEnnemi Start");
    }

    // Update is called once per frame
    protected void Update()
    {
        if (vie <= 0)
            Destroy(this.gameObject);
    }
 
    public void perdreVie()
    {
        vie--;
    }

}