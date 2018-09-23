using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour {
	public float speed_x=60f,speed_y=40f;
	//Vector2 range = new Vector2(100f, 80f); // 定义一个二维向量  
	//记录组件初始的旋转角度四元数
	Quaternion mStart;
	//初始化为0
	Vector2 mRot = Vector2.zero;  
	// Use this for initialization  
	void Start () {
		mStart = transform.localRotation;  // 获取当前组件的本地旋转四元数  
	}
	void Update(){
		Vector3 pos = Input.mousePosition;   //  获取鼠标位置  
		float halfWidth = Screen.width * 0.5f;   // 相对原点x  
		float halfHeight = Screen.height * 0.5f; // 相对原点y  
		float x = Mathf.Clamp ((pos.x - halfWidth) / halfWidth, -1f, 1f);  // 返回一个【-1,1】的x值  
		float y = Mathf.Clamp ((pos.y - halfHeight) / halfHeight, -1f, 1f); // 返回一个【-1,1】的x值  
		//基于浮点数t返回a到b之间的插值，t限制在0～1之间。当t = 0返回from，当t = 1 返回to。当t = 0.5 返回from和to的平均值  
		// Quaternion.Euler(new Vector3（）)  返回一个旋转角度，绕z轴旋转z度，绕x轴旋转x度，绕y轴旋转y度（像这样的顺序）。

		// 插值运算，这一步很重要，使元素的旋转看起来较为流畅
		mRot = Vector2.Lerp (mRot,new Vector2 (x, y), Time.deltaTime); 
		//transform.localRotation = mStart * Quaternion.Euler (-mRot.x * speed_x, mRot.y * speed_y, 0f);
		transform.localRotation = Quaternion.Euler (-mRot.x * speed_x, mRot.y * speed_y, 0f);
	}
}
