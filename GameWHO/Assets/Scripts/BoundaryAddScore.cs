using UnityEngine;
using System.Collections;

public class BoundaryAddScore : MonoBehaviour {

    private GamePlay gamePlay;
    public GameObject perfectPrefab;
    public Transform perfectContainer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "item") 
        {
            TypeController typeController = col.GetComponent<TypeController>();
            if (typeController != null && Input.GetButton("Fire1") == true) 
            {
                typeController.diem = 20;
                GameObject perfectObj = Instantiate(perfectPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                perfectObj.transform.SetParent(perfectContainer);
                perfectObj.GetComponent<PerfectController>().MoveStart();

            }
            
        }
    }

    [ContextMenu("TestPerfect")]
    void TestPerfect() 
    {
		if (Input.GetButton ("Fire1")) {
			GameObject perfectObj = Instantiate (perfectPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			perfectObj.transform.SetParent (perfectContainer);
			perfectObj.GetComponent<PerfectController> ().MoveStart ();
		}
    }
}
