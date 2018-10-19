using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColorViaSlider : MonoBehaviour {
    public Slider sliderRed;
    public Slider sliderGreen;
    public Slider sliderBlue;
    //public Slider sliderBrightness;
    private Material material;
    private TrailRenderer tr;
    private Color colorNew = Color.white;

    // Use this for initialization
    void Start () {
        tr = gameObject.GetComponent<TrailRenderer>();
        material = tr.material;
        material.color = colorNew;
	}
	
	// Update is called once per frame
	void Update () {
        colorNew.r = sliderRed.value;
        colorNew.b = sliderBlue.value;
        colorNew.g = sliderGreen.value;
        colorNew.a = 1;
            //sliderBrightness.value;

        material.color = colorNew;
        material.SetColor("_EmissionColor", colorNew);
	}

}
