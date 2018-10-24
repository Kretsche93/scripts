using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class setBrightness : MonoBehaviour {

    private Slider slider;
    private int sliderValueOld;
    private int sliderValueNew;
    string url = "http://192.168.25.105/api/1LvlwLpMQlOd4tFNn1pniLoImIcEx8aiv0YOZcLM/groups/6/action";
    

    // Use this for initialization
    void Start () {
        slider = gameObject.GetComponent<Slider>();
        slider.wholeNumbers = true;
        slider.value = slider.maxValue;
        sliderValueOld = (int)slider.value;        
	}
	
	// Update is called once per frame
	void Update () {
        sliderValueNew = (int)slider.value;

		if(sliderValueOld != sliderValueNew)
        {
            string brightnessChanged = "{\"bri\":" + sliderValueNew + "}";
            UnityWebRequest www = UnityWebRequest.Put(url, brightnessChanged);
            www.SendWebRequest();
            sliderValueOld = sliderValueNew;
        }
	}
}
