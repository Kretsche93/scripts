using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Meta/Interaction/TidyScript")]
public class Tidy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5f);
	}
}
