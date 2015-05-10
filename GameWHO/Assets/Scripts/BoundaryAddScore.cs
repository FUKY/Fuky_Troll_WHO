using UnityEngine;
using System.Collections;

public class BoundaryAddScore : MonoBehaviour {

    private GamePlay gamePlay;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "item") 
        {
            TypeController typeController = col.GetComponent<TypeController>();
            if (typeController != null) 
            {
                typeController.diem = 20;
            }
            
        }
        
    }
}
