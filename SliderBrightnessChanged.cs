using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SliderBrightnessChanged : MonoBehaviour {
    private Slider slider;
    //string url = "http://192.168.25.105/api/1LvlwLpMQlOd4tFNn1pniLoImIcEx8aiv0YOZcLM/lights/12/state";
    string url = "http://192.168.25.105/api/1LvlwLpMQlOd4tFNn1pniLoImIcEx8aiv0YOZcLM/groups/6/action";

    // Use this for initialization
    public void Start () {
        slider = GameObject.Find("SliderBrightness").GetComponent<Slider>();
        slider.onValueChanged.AddListener(onValueChangedListener);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void onValueChangedListener(float value)
    {
        string changedBrightness = "{\"bri\":" + value + "}";
        UnityWebRequest www = UnityWebRequest.Put(url, changedBrightness);
        www.SendWebRequest();
    }
}
