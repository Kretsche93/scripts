using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColorViaSlider : MonoBehaviour {
    public Slider sliderRed;
    public Slider sliderGreen;
    public Slider sliderBlue;
    public Slider brushWidthSlider;
    private Material material;
    private TrailRenderer tr;
    private Color colorNew = Color.white;


    // Use this for initialization
    void Start () {
        sliderRed = GameObject.Find("SliderRed").GetComponent<Slider>();
        sliderGreen = GameObject.Find("SliderGreen").GetComponent<Slider>();
        sliderBlue = GameObject.Find("SliderBlue").GetComponent<Slider>();
        brushWidthSlider = GameObject.Find("SliderWidth").GetComponent<Slider>();
        tr = gameObject.GetComponent<TrailRenderer>();

        material = new Material(Shader.Find("Standard"));
        material.color = colorNew;
        material.EnableKeyword("_EMISSION");
        tr.material = material;
        //colorCube.GetComponent<MeshRenderer>().material = material;
        //sphere.GetComponent<MeshRenderer>().material = material;        
    }
	
	// Update is called once per frame
	void Update () {
        colorNew.r = sliderRed.value;
        colorNew.b = sliderBlue.value;
        colorNew.g = sliderGreen.value;
        colorNew.a = 1;
        tr.widthMultiplier = brushWidthSlider.value;

        material.color = colorNew;
        material.SetColor("_EmissionColor", colorNew);
    }

}
