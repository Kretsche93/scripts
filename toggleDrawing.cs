using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleDrawing : MonoBehaviour {
    private GameObject sphere;
    private TrailRenderer trailRenderer;
    //private GameObject trailRendererOld;
    public GameObject drawingEnabled;
    public GameObject drawingDisabled;
    //private MeshRenderer textEnabled;
    //private MeshRenderer textDisabled;
    public GameObject TrailRendererPrefab;
    public GameObject brush;
    private Vector3 _localOffset;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    
    }
    private void OnButtonClick () {
        Transform brushParent = brush.GetComponent<Transform>();

        //textEnabled = drawingEnabled.GetComponent<MeshRenderer>();
        //textDisabled = drawingDisabled.GetComponent<MeshRenderer>();
        sphere = GameObject.Find("Sphere");
        trailRenderer = sphere.GetComponentInChildren<TrailRenderer>();
        //trailRendererOld = GameObject.Find("oldTrailRenderer");

        if (drawingEnabled.activeSelf)
        {
            drawingEnabled.SetActive(false);
            drawingDisabled.SetActive(true);
            trailRenderer.name = "oldTrailRenderer";
            trailRenderer.transform.parent = null;

            //if (trailrendererold)
            //{
            //    destroy(trailrendererold);
            //}
        }

        else
        {

            GameObject trailRendererNew = Instantiate(TrailRendererPrefab, brushParent);
            trailRendererNew.name = "TrailRenderer";
            drawingEnabled.SetActive(true);
            drawingDisabled.SetActive(false);

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
