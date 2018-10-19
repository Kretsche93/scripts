using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleDrawing : MonoBehaviour {
    private GameObject sphere;
    private Transform trailRendererTrans;
    private changeColorViaSlider trailRendererScript;
    public GameObject drawingEnabled;
    public GameObject drawingDisabled;
    public GameObject TrailRendererPrefab;
    public GameObject brush;
    private Vector3 _localOffset;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    
    }
    private void OnButtonClick () {
        Transform sphereParent = brush.transform.GetChild(1).GetComponent<Transform>();


        sphere = GameObject.Find("Sphere");
        


        if (drawingEnabled.activeSelf)
        {
            drawingEnabled.SetActive(false);
            drawingDisabled.SetActive(true);
            trailRendererTrans = sphere.transform.GetChild(0);
            trailRendererScript = sphere.GetComponentInChildren<changeColorViaSlider>();
            trailRendererTrans.name = "oldTrailRenderer";
            trailRendererTrans.transform.parent = null;
            Destroy(trailRendererScript);



        }

        else
        {

            GameObject trailRendererNew = Instantiate(TrailRendererPrefab, sphereParent);
            trailRendererNew.name = "TrailRenderer";
            trailRendererNew.AddComponent<changeColorViaSlider>();            
            drawingEnabled.SetActive(true);
            drawingDisabled.SetActive(false);

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
