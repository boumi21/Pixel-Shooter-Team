using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {


	public Text txtPoints;

	// Use this for initialization
	void Start () {
		txtPoints.text = "Score : " + ManegerDeGame.game.score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
