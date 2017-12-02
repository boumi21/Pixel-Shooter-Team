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
	public GameObject[] mur;

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
		placerMur ();
	}
	private void placerSol()
	{
		foreach (Vector3 place in positions) 
		{
			GameObject instance = Instantiate (grass, place, Quaternion.identity);
			instance.transform.SetParent (carte.transform);
		}
	}
	private void placerMur()
	{
		longueur++;
		for (byte x = 2; x > 0; x--)
			for (byte y = hauteur; y > 0; y--) 
			{
				if (x == 2) 
				{
					GameObject instance = Instantiate (mur [1], new Vector3 (31, y, 0f), Quaternion.identity);
					instance.transform.parent = carte.transform;
				} else 
				{
					GameObject instance = Instantiate (mur [1], new Vector3 (0, y, 0f), Quaternion.identity);
					instance.transform.parent = carte.transform;
				}
			}
		for (byte y = 2; y > 0; y--)
			for (byte x = longueur; x > 0; x--) 
			{
				if (y == 2) 
				{
					GameObject instance = Instantiate (mur [0], new Vector3 (x, 21, 0f), Quaternion.identity);
					instance.transform.parent = carte.transform;
				} else 
				{
					GameObject instance = Instantiate (mur [0], new Vector3 (x, 0, 0f), Quaternion.identity);
					instance.transform.parent = carte.transform;
				}
			}
		GameObject un = Instantiate (mur [0], new Vector3 (0, 21, 0f), Quaternion.identity);
		GameObject deux = Instantiate (mur [0], new Vector3 (0, 21, 0f), Quaternion.identity);
	}
}
