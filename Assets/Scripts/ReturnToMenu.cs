using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Application.loadedLevel != 0) {
				Application.LoadLevel ("title");
			} else {
				Debug.Log ("Quit requested");
				Application.Quit ();
			}
		}
	}
}
