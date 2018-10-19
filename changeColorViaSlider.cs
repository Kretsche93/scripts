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
        sliderRed = GameObject.Find("SliderRed").GetComponent<Slider>();
        sliderGreen = GameObject.Find("SliderGreen").GetComponent<Slider>();
        sliderBlue = GameObject.Find("SliderBlue").GetComponent<Slider>();
        tr = gameObject.GetComponent<TrailRenderer>();
        //material = tr.material;
        material = new Material(Shader.Find("Standard"));
        material.color = colorNew;
        tr.material = material;
        
    }
	
	// Update is called once per frame
	void Update () {
        colorNew.r = sliderRed.value;
        colorNew.b = sliderBlue.value;
        colorNew.g = sliderGreen.value;
        colorNew.a = 1;
            //sliderBrightness.value;

        material.color = colorNew;
        colorNew.r = colorNew.r - 0.1f;
        colorNew.g = colorNew.g - 0.1f;
        colorNew.b = colorNew.b - 0.1f;
        material.SetColor("_EmissionColor", colorNew);
	}

}
