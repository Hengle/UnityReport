using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public Bound bound;
	[SerializeField]
	private float speed=2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//接收输入
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		//处理输入
		transform.GetComponent<Rigidbody>().velocity=new Vector3(h*speed,v*speed,0);
		//边界设置
		transform.position=new Vector3(Mathf.Clamp(transform.position.x,bound.xMin,bound.xMax),
			Mathf.Clamp(transform.position.y,bound.yMin,bound.yMax),transform.position.z);
	}
}
