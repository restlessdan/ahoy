using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	
	//public static int musicPlayers = 0;
	static MusicPlayer instance = null;

	void Awake(){
		Debug.Log ("music player Awake " + GetInstanceID ());
		if (instance != null) {
			Destroy (gameObject);
			print ("destroying duplicate music player");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
	//Bug explanation each instance is given an individual id so they are both called in to view
	// until its checked that if its duplicated.
	
	// Update is called once per frame
	void Update () {
	}
}
