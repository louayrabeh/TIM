using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimRight : MonoBehaviour {
    double x = -0.1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, (float)x + Time.deltaTime, 0);
    }
}
