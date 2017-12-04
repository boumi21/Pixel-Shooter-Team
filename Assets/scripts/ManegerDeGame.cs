using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class ManegerDeGame : MonoBehaviour {

	private int vie =  5;
	[HideInInspector]public int score = 0;
	private int noDeLevel = 0;

	public Text vieT;
	public Text scoreT;

	public AudioClip hit;
	public AudioClip coin;

	public AudioSource[] sources;
	public static ManegerDeGame game =  null;


	void Awake()
	{
		if (game == null)
			game = this;
		else
			Destroy (gameObject);
	}
	public void gagnerPoints()
	{
		score++;
		if (score % 10 == 0)
			gagner ();	
		sources [1].clip = coin;
		sources [1].Play();
		scoreT.text = score + " points";
	}
	public void prendreDegat()
	{
		vie--;
		if(vie <= 0)
			fail();
		sources [1].clip = hit;
		sources [1].Play();
		vieT.text = vie + " vie restantes";
	}
	private void fail()
	{
		EditorSceneManager.LoadScene (5);
	}
	private void gagner()
	{
		EditorSceneManager.LoadScene (1);
		noDeLevel++;
	}
	void Start () 
	{
		DontDestroyOnLoad (this);
		vieT.text = vie + " vie restantes";
		scoreT.text = score + " points";
	}
}
