using UnityEngine;
using System.Collections;

public class TypeController : MonoBehaviour {

    public int inDex;
    private Controller control;
	// Use this for initialization
	void Start () {
        control = gameObject.GetComponentInParent<Controller>();
        if (control == null)
        {
            Debug.Log("chua co");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void CheckIndex(int indexButton)
    {
        if (inDex == indexButton)
        {
            control.AddScore();
            control.RandomType();
            Destroy(gameObject);
        }
        else
        {
            control.GameOver();
        }
    }
}
