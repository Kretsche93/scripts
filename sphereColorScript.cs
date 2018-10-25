using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sphereColorScript : MonoBehaviour {

    private Slider sliderRed;
    private Slider sliderGreen;
    private Slider sliderBlue;
    private Slider sliderWidth;
    private GameObject colorCube;
    private GameObject sphere;
    private Color colorNew = Color.white;
    private Material material;
    private Vector3 sphereWidth;

    // Use this for initialization
    void Start () {
        sliderRed = GameObject.Find("SliderRed").GetComponent<Slider>();
        sliderGreen = GameObject.Find("SliderGreen").GetComponent<Slider>();
        sliderBlue = GameObject.Find("SliderBlue").GetComponent<Slider>();
        sliderWidth = GameObject.Find("SliderWidth").GetComponent<Slider>();
        colorCube = gameObject;
        sphere = GameObject.Find("Sphere");
        material = new Material(Shader.Find("Standard"));
        material.color = colorNew;
        material.EnableKeyword("_EMISSION");
        colorCube.GetComponent<MeshRenderer>().material = material;
        sphere.GetComponent<MeshRenderer>().material = material;
        sphereWidth = sphere.transform.localScale;
        sphereWidth.Set(sliderWidth.value/10, sliderWidth.value/10, sliderWidth.value/10);
        sphere.transform.localScale = sphereWidth;
    }
	
	// Update is called once per frame
	void Update () {
        colorNew.r = sliderRed.value;
        colorNew.b = sliderBlue.value;
        colorNew.g = sliderGreen.value;
        colorNew.a = 1;

        material.color = colorNew;
        sphere.GetComponent<MeshRenderer>().material.color = colorNew;
        gameObject.GetComponent<MeshRenderer>().material.color = colorNew;
        material.SetColor("_EmissionColor", colorNew);
        colorCube.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colorNew);
        sphere.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colorNew);
        sphereWidth = sphere.transform.localScale;
        sphereWidth.Set(sliderWidth.value / 10, sliderWidth.value / 10, sliderWidth.value / 10);
        sphere.transform.localScale = sphereWidth;
    }
}
