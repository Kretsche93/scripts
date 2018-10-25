using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.HandInput;

public class resetPosition : MonoBehaviour {
    private Vector3 startingPos;
    private Vector3 currentPos;
    private Quaternion startingRot;
    private float _gravity = -9.81f;

    void Start() {
        startingPos = gameObject.transform.position;
        startingRot = gameObject.transform.rotation;
        Physics.gravity = new Vector3(0, _gravity, 0);
    }
        		
	void Update () {
        currentPos = gameObject.transform.position;

        if (currentPos.y < -3)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.transform.rotation = startingRot;
            gameObject.transform.position = startingPos; 
        }
	}
}
