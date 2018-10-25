using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.HandInput;

public class RespawnCubes : MonoBehaviour {

    private GameObject targetCube;
    private GameObject targetCube2;
    private GameObject targetCube3;
    private GameObject targetCube4;
    private GameObject targetCube5;
    private GameObject targetCube6;
    private GameObject targetCube7;
    private GameObject targetCube8;
    private GameObject targetCube9;
    private GameObject shootingCube;

    private Vector3 startingPos;
    private Vector3 startingPos2;
    private Vector3 startingPos3;
    private Vector3 startingPos4;
    private Vector3 startingPos5;
    private Vector3 startingPos6;
    private Vector3 startingPos7;
    private Vector3 startingPos8;
    private Vector3 startingPos9;
    private Quaternion startingRot;
    private Quaternion startingRot2;
    private Quaternion startingRot3;
    private Quaternion startingRot4;
    private Quaternion startingRot5;
    private Quaternion startingRot6;
    private Quaternion startingRot7;
    private Quaternion startingRot8;
    private Quaternion startingRot9;

    private void Start()
    {
        targetCube = GameObject.Find("TargetCube1");
        targetCube2 = GameObject.Find("TargetCube2");
        targetCube3 = GameObject.Find("TargetCube3");
        targetCube4 = GameObject.Find("TargetCube4");
        targetCube5 = GameObject.Find("TargetCube5");
        targetCube6 = GameObject.Find("TargetCube6");
        targetCube7 = GameObject.Find("TargetCube7");
        targetCube8 = GameObject.Find("TargetCube8");
        targetCube9 = GameObject.Find("TargetCube9");
        shootingCube = GameObject.Find("ShootingCube");

        startingPos = targetCube.transform.position;
        startingRot = targetCube.transform.rotation;

        startingPos2 = targetCube2.transform.position;
        startingRot2 = targetCube2.transform.rotation;

        startingPos3 = targetCube3.transform.position;
        startingRot3 = targetCube3.transform.rotation;

        startingPos4 = targetCube4.transform.position;
        startingRot4 = targetCube4.transform.rotation;

        startingPos5 = targetCube5.transform.position;
        startingRot5 = targetCube5.transform.rotation;

        startingPos6 = targetCube6.transform.position;
        startingRot6 = targetCube6.transform.rotation;

        startingPos7 = targetCube7.transform.position;
        startingRot7 = targetCube7.transform.rotation;

        startingPos8 = targetCube8.transform.position;
        startingRot8 = targetCube8.transform.rotation;

        startingPos9 = targetCube9.transform.position;
        startingRot9 = targetCube9.transform.rotation;
    }

    public void CallRespawn()
    {
        StartCoroutine("Respawn");
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2.1f);
        targetCube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube.transform.rotation = startingRot;
        targetCube.transform.position = startingPos;
        targetCube2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube2.transform.rotation = startingRot2;
        targetCube2.transform.position = startingPos2;
        targetCube3.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube3.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube3.transform.rotation = startingRot3;
        targetCube3.transform.position = startingPos3;
        targetCube4.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube4.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube4.transform.rotation = startingRot4;
        targetCube4.transform.position = startingPos4;
        targetCube5.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube5.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube5.transform.rotation = startingRot5;
        targetCube5.transform.position = startingPos5;
        targetCube6.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube6.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube6.transform.rotation = startingRot6;
        targetCube6.transform.position = startingPos6;
        targetCube7.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube7.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube7.transform.rotation = startingRot7;
        targetCube7.transform.position = startingPos7;
        targetCube8.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube8.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube8.transform.rotation = startingRot8;
        targetCube8.transform.position = startingPos8;
        targetCube9.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetCube9.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        targetCube9.transform.rotation = startingRot9;
        targetCube9.transform.position = startingPos9;
    }
}
