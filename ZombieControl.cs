using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : MonoBehaviour {

	private Animation zombieanimation;
	private bool shouldMove = false;

	// Use this for initialization
	void Start () {

		zombieanimation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (shouldMove) {

			transform.Translate (Vector3.forward * Time.deltaTime * (transform.localScale.x * .05f));
		}
	}

	public void Walk(){

		if (!zombieanimation.isPlaying) {

			zombieanimation.Play ();
			shouldMove = true;
		} else {
			zombieanimation.Stop ();
			shouldMove = false;
		}
	}

	public void LookAt(){

		transform.LookAt (Camera.main.transform.position);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
	}

	public void Bigger(){

		transform.localScale += new Vector3 (1, 1, 1);
	}

	public void Smaller(){

		if (transform.localScale.x > 1) {
			transform.localScale -= new Vector3 (1, 1, 1);
		}
	}
}