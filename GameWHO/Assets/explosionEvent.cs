using UnityEngine;
using System.Collections;

public class explosionEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroyByLastFrame()
	{
		Destroy (gameObject);
	}
}
