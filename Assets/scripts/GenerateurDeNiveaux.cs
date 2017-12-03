using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class GenerateurDeNiveaux : MonoBehaviour {

	public byte hauteur = 20;
	public byte longueur = 30;
	public byte quantiterLake = 3;

	public int quantiterCoins = 10;
	public int quantiterEnemys = 10;
	public int quantiterDragons = 2;
	public int quantiterBlockers = 50;
	public int quantiterDecorations = 150;
	public int quantiterPointsPath = 5;

	private List<Vector3> positions = new List<Vector3>();
	[HideInInspector]public GameObject carte;
	[HideInInspector]public List<GameObject> listePath = new List<GameObject>();
	[HideInInspector] public  List <GameObject> joueur;

	public GameObject pathPoint;
	public GameObject persoPrinc;
	public GameObject coin;
	public GameObject dragon;
	public GameObject grass;

	public GameObject[] enemys;
	public GameObject[] lake;
	public GameObject[] blockers;
	public GameObject[] decorations;
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
		placerLake ();
		placerMur ();
		spawner (quantiterBlockers, blockers);
		spawner (quantiterDecorations, decorations);
		spawner (quantiterEnemys, enemys);
		spawner (quantiterDragons, dragon);
		spawner (quantiterCoins, coin);
		joueur = spawner (1, persoPrinc);
		listePath = spawner (quantiterPointsPath, pathPoint);
	}
	private void placerSol()
	{
		foreach (Vector3 place in positions) 
		{
			GameObject instance = Instantiate (grass, place, Quaternion.identity);
			instance.transform.SetParent (carte.transform);
		}
	}
	private void placerLake()
	{
		for(byte i = quantiterLake; i > 0; i--)
		{
			List<Vector3> lakep = new List<Vector3>();
			lakep.Add( new Vector3(Random.Range(5, longueur - 5), Random.Range(5, hauteur - 5), 0f)) ;
			lakep.Add(new Vector3 (lakep[0].x + 1, lakep[0].y, 0f));
			lakep.Add(new Vector3 (lakep[0].x, lakep[0].y - 1, 0f));
			lakep.Add(new Vector3 (lakep[1].x, lakep[1].y - 1, 0f));
			int j = 0;
			foreach (Vector3 p in lakep) 
			{
				GameObject instance = Instantiate (lake[j], p, Quaternion.identity);
				instance.transform.parent = carte.transform;
				j++;
				positions.Remove (p);
			}
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
					GameObject instance = Instantiate (mur [1], new Vector3 (longueur, y, 0f), Quaternion.identity);
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
					GameObject instance = Instantiate (mur [0], new Vector3 (x, hauteur + 1, 0f), Quaternion.identity);
					instance.transform.parent = carte.transform;
				} else 
				{
					GameObject instance = Instantiate (mur [0], new Vector3 (x, 0, 0f), Quaternion.identity);
					instance.transform.parent = carte.transform;
				}
			}
		GameObject un = Instantiate (mur [0], new Vector3 (0, hauteur + 1, 0f), Quaternion.identity);
		GameObject deux = Instantiate (mur [0], new Vector3 (0, 0, 0f), Quaternion.identity);
		un.transform.parent = carte.transform;
		deux.transform.parent = carte.transform;
	}
	private void placerBlockers()
	{
		for (int i = quantiterBlockers; i > 0; i--) 
		{
			Vector3 emplacement = positions[Random.Range (0, positions.Count)];
			GameObject instance = Instantiate(blockers[Random.Range(0, blockers.Length)], emplacement, Quaternion.identity);
			positions.Remove (emplacement);
			instance.transform.parent = carte.transform;
		}
	}
	private List<GameObject> spawner(int quantiter, GameObject[] objet)
	{
		List<GameObject> instances = new List<GameObject> ();
		for (int i = quantiter; i > 0; i--) 
		{
			Vector3 emplacement = positions[Random.Range (0, positions.Count)];
			GameObject instance = Instantiate(objet[Random.Range(0, objet.Length)], emplacement, Quaternion.identity);
			positions.Remove (emplacement);
			instance.transform.parent = carte.transform;
			instances.Add (instance);
		}
		return instances;
	}
	private List<GameObject> spawner(int quantiter, GameObject objet)
	{
		List<GameObject> instances = new List<GameObject> ();
		for (int i = quantiter; i > 0; i--) 
		{
			Vector3 emplacement = positions [Random.Range (0, positions.Count)];
			GameObject instance = Instantiate (objet, emplacement, Quaternion.identity);
			positions.Remove (emplacement);
			instance.transform.parent = carte.transform;
			instances.Add (instance);
		}
		return instances;
	}
}