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
    public GameObject colorCube;
    //public Material colorCubeMat;

    // Use this for initialization
    void Start () {
        sliderRed = GameObject.Find("SliderRed").GetComponent<Slider>();
        sliderGreen = GameObject.Find("SliderGreen").GetComponent<Slider>();
        sliderBlue = GameObject.Find("SliderBlue").GetComponent<Slider>();
        tr = gameObject.GetComponent<TrailRenderer>();
        colorCube = GameObject.Find("Colorcube");
        //colorCubeMat = GameObject.Find("Colorcube").GetComponent<MeshRenderer>().material;
        //material = tr.material;
        material = new Material(Shader.Find("Standard"));
        material.color = colorNew;
        tr.material = material;
        colorCube.GetComponent<MeshRenderer>().material = material;
        //colorCubeMat = material;
        
    }
	
	// Update is called once per frame
	void Update () {
        colorNew.r = sliderRed.value;
        colorNew.b = sliderBlue.value;
        colorNew.g = sliderGreen.value;
        colorNew.a = 1;
            //sliderBrightness.value;

        material.color = colorNew;
        colorCube.GetComponent<MeshRenderer>().material.color = colorNew;
        colorNew.r = colorNew.r - 0.1f;
        colorNew.g = colorNew.g - 0.1f;
        colorNew.b = colorNew.b - 0.1f;
        material.SetColor("_EmissionColor", colorNew);
        colorCube.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colorNew);
    }

}
