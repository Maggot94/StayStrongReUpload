using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemiesController : MonoBehaviour
{

	public Transform spawnPoint;
	public GameObject Enemy;
	private float oleada, cantEnemigos;
	private GameObject en;
	private bool once, once1;

	void Start ()
	{
		once = true;
		once1 = true;
		oleada = 1f;
		//cantEnemigos = Mathf.Pow (2, oleada+3);
		cantEnemigos = Mathf.Pow (2, oleada);
		Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
        NotificationCenter.DefaultCenter().AddObserver(this, "AnotherEnemy");
	}

    private void AnotherEnemy()
    {
		Invoke("SpawnEnemy", 1f);
    }
    void SpawnEnemy()
    {
		if(cantEnemigos>0){
			Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
			cantEnemigos -= 1;
		}
		if (cantEnemigos == 0) {
			oleada++;

			//Mathf.Exp (2, oleada + 3);
			cantEnemigos = Mathf.Pow (2, oleada);
		}
		Debug.Log (oleada+" "+ cantEnemigos);
    }
	void Update(){
		if (oleada == 2) {
			en=GameObject.Find ("Enemigo(Clone)");
			en.GetComponent<Enemigo> ().ChangeStay (5f);
			en.GetComponent<Animator> ().speed = 2;
			once = false;
		}
		if (oleada == 3) {
			en=GameObject.Find ("Enemigo(Clone)");
			en.GetComponent<Animator> ().speed = 3;
			once1 = false;
		}

	}
}
