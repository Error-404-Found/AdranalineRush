using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Walk : MonoBehaviour {
	public int speed = 3;

	public bool moveforward = false;

	public int count;

	public Text ctext;


	// Use this for initialization
	void Start () {
		count = 12;
		Counter ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
		
			moveforward = !moveforward;
		}

		if (moveforward) {

	transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

		}

		if (transform.position.y < -15) {
			SceneManager.LoadScene ("MainScene");
}

	}

	public void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag ("Cubetags")) {
			count = count - 1;
			Counter ();
			Destroy (other.gameObject);
		}

		if (count == 0 && other.gameObject.CompareTag ("Trophytag")) {
			SceneManager.LoadScene ("EndScene");
		}

		if (count == 0) {
			ctext.text = "GO FOR THE TROPHY";
		}
	}

	public void Counter()
	{
		ctext.text = "COUNT: " + count.ToString ();
	}	
}






