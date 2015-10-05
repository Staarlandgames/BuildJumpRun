using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Shader shader;

	void Start () 
	{
		Camera.main.SetReplacementShader (shader, "RenderType");
	}

	void Update () {
	
	}
}
