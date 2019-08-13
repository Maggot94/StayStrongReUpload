using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punkos : MonoBehaviour {

	public GameObject enemigo;
	private Animator an;

	// Use this for initialization
	void Start () 
	{
		enemigo = GameObject.Find("Enemigo(Clone)");
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemigo = GameObject.Find("Enemigo(Clone)");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
	}	
}
