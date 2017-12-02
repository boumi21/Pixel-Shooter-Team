using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class GenerateurDeNiveaux : MonoBehaviour {

	private byte hauteur = 20;
	private byte longueur = 30;
	private int quantiterBlockers = 200;
	private int quantiterDecorations = 300;
	private List<Vector3> positions = new List<Vector3>();
	public GameObject carte;

	public GameObject[] blockers;
	public GameObject[] decorations;
	public GameObject grass;

	void Start ()
	{
		carte = new GameObject ("carte");
		for (byte x = longueur; x > 0; x--)
			for (byte y = hauteur; y > 0; y--) 
				positions.Add (new Vector3 (x, y, 0f));
			
		generation ();
	}
	private void generation()
	{
		placerSol ();
	}
	private void placerSol()
	{
		foreach (Vector3 place in positions) 
		{
			GameObject instance = Instantiate (grass, place, Quaternion.identity);
			instance.transform.SetParent (carte.transform);
		}
	}
}
