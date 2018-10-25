using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Meta/Interaction/TidyScript")]
public class Tidy : MonoBehaviour {

    public bool shootingEnabled;

    private void Update()
    {
        shootingEnabled = Meta.shootInteraction.engaged;
        if (shootingEnabled == false)
        {
            Destroy(gameObject, 2f);
        }
    }
}
