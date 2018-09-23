using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
	private LineRenderer lineRenderer;
	private int index=0;
	public GameObject line;
	// Use this for initialization
	void Start () {
		if (null != line) {
			//lineRenderer = line.GetComponent<LineRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject clone;
		if (Input.GetMouseButtonDown (0)) {
			clone = (GameObject)Instantiate (line,line.transform.position,line.transform.rotation);
			lineRenderer = line.GetComponent<LineRenderer> ();
			index = 0;
		}
		if (Input.GetMouseButton (0)) {
			
			index++;
			lineRenderer.positionCount = index;
			lineRenderer.SetPosition (index-1,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,15)));
		}
	}
}
