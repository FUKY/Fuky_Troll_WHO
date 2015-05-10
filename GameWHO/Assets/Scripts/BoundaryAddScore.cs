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
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "item") 
        {
            TypeController typeController = col.GetComponent<TypeController>();
            if (typeController != null) 
            {
                typeController.diem = 20;
                GameObject perfectObj = Instantiate(perfectPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                perfectObj.transform.SetParent(perfectContainer);
                perfectObj.GetComponent<PerfectController>().MoveStart();
                //perfectContainer.GetComponent<P

            }
            
        }
        
    }

    [ContextMenu("TestPerfect")]
    void TestPerfect() 
    {
        GameObject perfectObj = Instantiate(perfectPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        perfectObj.transform.SetParent(perfectContainer);
        perfectObj.GetComponent<PerfectController>().MoveStart();
    }
}
