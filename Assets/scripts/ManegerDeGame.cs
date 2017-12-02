using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class ManegerDeGame : MonoBehaviour {

	private int vie =  5;
	private int score = 0;
	private int noDeLevel = 0;


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
			fail ();
			
	}
	public void prendreDegat()
	{
		vie--;
		if(vie <= 0)
			gagner();
	}
	private void fail()
	{
		EditorSceneManager.LoadScene (0);
	}
	private void gagner()
	{
		EditorSceneManager.LoadScene (1);
	}
	void Start () 
	{
		DontDestroyOnLoad (this);
	}
}
