using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 绘制曲线
/// </summary>
public class GLDrawLine : MonoBehaviour
{
	/// <summary>
	/// 绘制线段材质
	/// </summary>
	public Material material;

	private List<List<Vector3>> lines;
	private List<Vector3> lineInfo;
	// Use this for initialization
	void Start()
	{
		lines = new List<List<Vector3>> ();
		//初始化鼠标线段链表
		//lineInfo = new List<Vector3>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			//每次点击鼠标后，都重新实例化lineInfo，将其置空，然后加入线段列表中
			lineInfo= new List<Vector3>();
			lines.Add (lineInfo);
		}
		//将每次鼠标改变的位置存储进链表
		if(Input.GetMouseButton(0)){
			lineInfo.Add(Input.mousePosition);
		}
			
		
	}

	private void OnGUI()
	{
		GUILayout.Label("当前鼠标x轴位置" + Input.mousePosition.x);
		GUILayout.Label("当前鼠标y轴位置" + Input.mousePosition.y);
	}

	private void OnPostRender()
	{
		if (!material)
		{
			Debug.LogError("请给材质资源赋值");
			return;
		}
		material.SetPass(3);//设置该材质通道，0为默认值
		//GL.PushMatrix();
		GL.LoadOrtho();//设置绘制2D图像
		GL.Begin(GL.LINES);//表示开始绘制，绘制类型为线段 
		for(int j=0;j<lines.Count;j++){
			lineInfo=lines[j];
			for (int i = 0; i < lineInfo.Count - 1; i++)
			{
				Vector3 start = lineInfo[i];
				Vector3 end = lineInfo[i + 1];
				//绘制线段
				DrawLine(start.x, start.y, end.x, end.y);
			}
		}

		GL.End();
		//GL.PopMatrix ();
	}
	/// <summary>
	/// 绘制线段
	/// </summary>
	/// <param name="x1"></param>
	/// <param name="y1"></param>
	/// <param name="x2"></param>
	/// <param name="y2"></param>
	private void DrawLine(float x1, float y1, float x2, float y2)
	{
		//绘制线段，需要将屏幕中某个点的像素坐标点除以屏幕宽或高
		GL.Vertex(new Vector3(x1 / Screen.width, y1 / Screen.height, 0));// [ˈvɜ:ˌteks] 最高点；顶点
		GL.Vertex(new Vector3(x2 / Screen.width, y2 / Screen.height, 0));
	}
}