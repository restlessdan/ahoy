using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sailcolors : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Color newSailColor = new Color(Random.value, Random.value, Random.value);
        Renderer sail_colors = GetComponent<Renderer>();
        sail_colors.material.color = newSailColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
