using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

	public int life = 100;
	public int damage = 10;
	public Image vida; 
	public float maxTime; 
	public float minSwipeDist;
	public int direcction; 
	public bool defense = false; 
	public float defensetime = 2f;

	public CameraShake cs; 

	public float damagetime = 1f; 
	public bool isDamage = false; 


	private Animator Dodge; 

	public Enemigo ene; 


	float startTime; 
	float endTime;

	Vector3 starPos;
	Vector3 endPos; 

	float SwipeDistance; 
	float SwipeTime;

	private BoxCollider2D def;

	public bool defrigth = false;
	public bool defleft = false; 

	[SerializeField]private float tiempoEntreDef;
	[SerializeField]private bool castigo;
	// Use this for initialization
	void Start () {
		castigo = false;
		tiempoEntreDef = 0;
		Dodge = GetComponent<Animator>(); 
		def= GetComponent<BoxCollider2D>(); 


	}
	
	// Update is called once per frame
	void Update () {

		/*if (isDamage == true) {
			damagetime -= Time.deltaTime; 
			if (damagetime <= 0) {

				Dodge.SetInteger ("Dodge", 0); 
				isDamage = false; 
				damagetime = 1f;
			}
           

		}
		*/

		if (defense == true) {

			defensetime -= Time.deltaTime;

			if (defensetime <= 0) {

				Dodge.SetInteger ("Dodge", 0);
				defensetime = 0.5f;
				defense = false;
				defrigth = false;
				defleft = false; 
				def.enabled = true; 

			}
		}
		if (Dodge.GetInteger("Dodge")==0&&castigo) {
			tiempoEntreDef -= Time.deltaTime;
			if (tiempoEntreDef <= 0) {
				castigo = false;
				tiempoEntreDef = 1;
			}
		}
		if (Dodge.GetInteger("Dodge")==0&&!castigo) {
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0);

				if (touch.phase == TouchPhase.Began) {
					startTime = Time.time;
					starPos = touch.position; 
				} else if (touch.phase == TouchPhase.Ended) {
					endTime = Time.time;
					endPos = touch.position;

					SwipeDistance = (endPos - starPos).magnitude;
					SwipeTime = endTime - startTime;
					if (SwipeTime < maxTime && SwipeDistance > minSwipeDist) {
						Debug.Log ("Andres es gay");
						Swipe ();
						castigo = true;
					}
				}
			}

		}
	}

	void Swipe ()
	{
		Vector2 distance = endPos - starPos;
		if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y) )
		{
			Debug.Log ("Horizonal Swipe");
			if (distance.x > 0) {
				Debug.Log ("Defensa Derecha"); 

				Dodge.SetInteger ("Dodge", 1);
				defense = true;
				defrigth = true;
				//def.enabled = false;


			}
			if (distance.x < 0) {
				Debug.Log ("Defensa Izquierda"); 
				Dodge.SetInteger ("Dodge", 2);
				defense = true; 
				defleft = true; 
				//def.enabled = false; 
				//Instantiate (Block, SpawnPoint.position, SpawnPoint.rotation);
			}
		}
    }

	public void isHurt()
	{
		if (defleft == true && ene.left == true) {

			life = life - 10;
			Debug.Log (life);
		}

		if (defrigth == true && ene.rigth == true) {

			life = life - 10;
			Debug.Log (life);

		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		
	       
		    //Dodge.SetInteger ("Dodge",3);
		    //isDamage = true;
		    cs.ShakeCamera (1f, 0.03f);
		    life = life - 10; 
		    vida.fillAmount -= 0.1f; 
			Debug.Log (life);
        if (life == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        //}
    }

}
