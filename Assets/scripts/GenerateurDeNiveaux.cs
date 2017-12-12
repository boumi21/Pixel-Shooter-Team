using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class GenerateurDeNiveaux : MonoBehaviour {

	public byte hauteur = 20;
    public byte longueur = 30;
    public int quantiterCoins = 10;
    //public int quantiterPointsPath = 5;

    private byte quantiterLake;
    private int quantiterEnemys;
    private int quantiterDragons;
    private int quantiterarbres;
    private int quantiterDecorations;
    private int quantiterPuits;
    private int quantiterRoches;

	private List<Vector3> positions = new List<Vector3>();
    private List<Vector3> sol = new List<Vector3>();

    [HideInInspector]public GameObject carte;
	[HideInInspector]public List<GameObject> listePath = new List<GameObject>();
	[HideInInspector]public List<GameObject> joueur;

	public GameObject pathPoint;
	public GameObject persoPrinc;
	public GameObject coin;
	public GameObject dragon;
	public GameObject grass;
    public GameObject puits;
    public GameObject roche;
    public GameObject lake;

    public GameObject[] enemys;	
	public GameObject[] arbres;
	public GameObject[] decorations;
	public GameObject[] mur;

	void Start ()
	{
        initialisation();	
		generation ();
	}
    private void initialisation()
    {
        int superficie = hauteur * longueur;

        carte = new GameObject("carte");
        for (byte x = longueur; x > 0; x--)
            for (byte y = hauteur; y > 0; y--)
                sol.Add(new Vector3(x, y, 0f));

        quantiterLake = (byte)Mathf.Floor(superficie / 600);
        quantiterEnemys = (int)Mathf.Floor(superficie / 60);
        quantiterDragons = (int)Mathf.Floor(superficie / 300);
        quantiterarbres = (int)Mathf.Floor(superficie / 12);
        quantiterDecorations = (int)Mathf.Floor(superficie / 4);
        quantiterPuits = (int)Mathf.Floor(superficie / 500);
        quantiterRoches = (int)Mathf.Floor(superficie / 100);
    }
	private void generation()
	{
        placerLake();
        placerSol ();
		placerMur ();

        positions = sol;

		spawner (quantiterarbres, arbres);
		spawner (quantiterDecorations, decorations);
		spawner (quantiterEnemys, enemys);
		spawner (quantiterDragons, dragon);
		spawner (quantiterCoins, coin);
        spawner (quantiterPuits, puits);
        spawner (quantiterRoches, roche);
        joueur = spawner (1, persoPrinc);
		//listePath = spawner (quantiterPointsPath, pathPoint);
	}
	private void placerSol()
	{
		foreach (Vector3 place in sol) 
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
            bool libre = false;
            while (!libre)
            {
                lakep = positionsLake(Random.Range(2, 12), Random.Range(2, 12));
                libre = positionsLibre(lakep, sol);
            }
			int j = 0;
			foreach (Vector3 p in lakep) 
			{
                if (p.x <= longueur -1 && p.y <= hauteur -1)
                {
                    GameObject instance = Instantiate(lake, p, Quaternion.identity);
                    instance.transform.parent = carte.transform;
                    sol.Remove(p);
                }
				j++;	
			}
		}
	}
    private bool positionsLibre(List<Vector3> coordoner, List<Vector3> endroi)
    {
        bool libre = false;
        foreach (Vector3 p in coordoner)
        {
            if (endroi.Contains(p))
                libre = true;
            else
                libre = false;
        }
        return libre;
    }
    private List<Vector3> positionsLake(int largeurL, int hauteurL)
    {
        List<Vector3> lakep = new List<Vector3>();
        lakep.Add(new Vector3(Random.Range(0, longueur), Random.Range(0, hauteur), 0f));
        for (int x = largeurL; x > -1; x--)
            for (int y = hauteurL; y > -1; y--)
                lakep.Add(new Vector3(lakep[0].x + x, lakep[0].y + y, 0f));
        return lakep;
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