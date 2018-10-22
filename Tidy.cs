using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Meta/Interaction/TidyScript")]
public class Tidy : MonoBehaviour {

    public bool shootingEnabled;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5f);
	}
    //private void Update()
    //{
    //    shootingEnabled = Meta.shootInteraction.engaged;
    //    if (shootingEnabled == false)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
