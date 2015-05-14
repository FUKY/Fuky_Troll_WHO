using UnityEngine;
using System.Collections;

public class PerfectController : MonoBehaviour {

    public Vector3 posStart;
    public Vector3 posMove;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MoveStart() 
    {
        	transform.localPosition = posStart;
        	iTween.MoveTo(gameObject, iTween.Hash(
            	iT.MoveTo.position, posMove,
            	iT.MoveTo.islocal, true,
            	iT.MoveTo.time, 1,
            	iT.MoveTo.easetype, iTween.EaseType.easeOutBack));
    }

    public  void FinishAnimation() 
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            iT.MoveTo.position, posStart,
            iT.MoveTo.islocal, true,
            iT.MoveTo.time, 0.2,
            iT.MoveTo.oncomplete, "DestroyGameObj",
            iT.MoveTo.oncompletetarget,gameObject));
    }

    public void DestroyGameObj() 
    {
        Destroy(gameObject);
    }
}
