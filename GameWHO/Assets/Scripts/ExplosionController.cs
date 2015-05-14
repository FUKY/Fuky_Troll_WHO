using UnityEngine;
using System.Collections;

public class ExplosionController : MonoSingleton<ExplosionController> {
	
	//public GameObject Icon;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ExplosionIcon(Transform icon)
	{
		Instantiate (explosion, icon.position, Quaternion.identity);
	}
}
