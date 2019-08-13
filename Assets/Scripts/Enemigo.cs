using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Enemigo : MonoBehaviour {

	public int vida = 100; 
	private Animator Ataques; 
	public Image life; 


	//--------------


	public GameObject pow; 



	private float TimeAttack=3f; 
	[SerializeField]private float stay=7f; 
	[SerializeField]private float maxStay=7f;

	private BoxCollider2D attack; 
	public bool rigth = false;
	public bool left = false; 
	public bool NextAttackBool = false; 

	public int StateAttack;

	public Vector3 mousePos ; 

	[SerializeField]private float tiempoCambioSprite;

	public GameObject Punos;
	public int punos;
	public bool nextGolpe;
	//----- parte roger---
	void Awake (){
		punos = 4;
		life.fillAmount = 1f; 
		vida = 100; 
		Punos = GameObject.Find ("Player");
		nextGolpe = true;

	}

	// Use this for initialization
	void Start () {
		//stay = 5f;
		//TimeAttack = 3f;
		tiempoCambioSprite=0.2f;
		Ataques = GetComponent<Animator> (); 
		attack = GetComponent<BoxCollider2D> (); 
	
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteRenderer> ().color == Color.red) {
			tiempoCambioSprite -= Time.deltaTime;
			if (tiempoCambioSprite <= 0) {
				GetComponent<SpriteRenderer> ().color = Color.white;
				tiempoCambioSprite = 0.2f;
			}
		}
		if (NextAttackBool == false) {

		
			stay -= Time.deltaTime;
			//pow.SetActive (false);
		}
		if (stay <= 3f) {
			
			//Ataques.SetInteger ("Attack", 0); 
			TimeAttack -= Time.deltaTime; 
			//attack.enabled = false; 
			left = false;
			rigth = false;
		}

		if (TimeAttack <= 0) {
			
			stay = maxStay; 
			NextAttackBool = true; 
		}
			
		if( NextAttackBool == true)
		{
			StateAttack = Random.Range (0, 3);
			Attack (StateAttack); 
		}
		if ((Punos.GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("AtaqueDerecha")||(Punos.GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("AtaqueIzquierda")))&&!nextGolpe)
		{
			nextGolpe = true;
			GetComponent<SpriteRenderer> ().color = Color.red;
			Punos.GetComponent<Animator> ().SetInteger ("Dodge", 0);
			vida = vida - 2;
			life.fillAmount -= 0.02f; 
			if (punos == 4) {
				punos = 5;
			} else {
				punos = 4;
			}
		}
	}

	public void Attack (int a) {
		
		if (a == 1) 
		{

			//Ataques.SetInteger ("Attack", a); 
			//attack.enabled = true;
			left = true; 
			NextAttackBool = false; 
			TimeAttack = 3f;

		}

		if (a == 2) 
		{
			//Ataques.SetInteger ("Attack", a); 
			//attack.enabled = true; 
			rigth = true; 
			NextAttackBool = false; 
			TimeAttack = 3f;
		}


	}

	void OnMouseOver()
	{
		if (!rigth && !left && nextGolpe ) {
			if (Input.GetMouseButtonDown (0)) {
				
				pow.SetActive (true);
				Punos.GetComponent<Animator> ().SetInteger ("Dodge", punos);
				nextGolpe = false;
				//Debug.Log("vida - 1");
			}
			if (vida == 0) {
				NotificationCenter.DefaultCenter ().PostNotification (this, "AnotherEnemy");
				NotificationCenter.DefaultCenter ().PostNotification (this, "SetCountText");
				Destroy (gameObject);
			}
		}
	}

	public void ChangeStay(float newStay){
		maxStay = newStay;
	}
}



