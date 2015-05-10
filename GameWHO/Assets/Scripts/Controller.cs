using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public GameObject[] listTypeParent;
    public GameObject[] listGear;
    public RectTransform rectTransform;
    public Transform transform;

    public float timeDelayRandom;
    private float timeDelay = 0;

    public int indexButton = 0;
    public int score;
    public Text textScore;
    void Awake()
    {
        score = 10;
    }
    // Use this for initialization
    void Start()
    {
        RandomType();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RandomType()
    {
        int index;
        int indexParent;
        int indexGear;
        index = Random.Range(0, 2);
        if (index == 0)
        {
            indexParent = Random.Range(0, 3);
            GameObject type = Instantiate(listTypeParent[indexParent], transform.position, Quaternion.identity) as GameObject;
            type.transform.SetParent(rectTransform);
            //type.transform.localPosition = Vector3.zero;
            type.transform.localScale = Vector3.one;
            type.GetComponent<TypeController>().inDex = index;
        }
        if(index == 1)
        {
            indexGear = Random.Range(0, 3);
            GameObject type = Instantiate(listGear[indexGear], transform.position, Quaternion.identity) as GameObject;
            type.transform.SetParent(rectTransform);
            //type.transform.localPosition = Vector3.zero;
            type.transform.localScale = Vector3.one;
            type.GetComponent<TypeController>().inDex = index;
        }
        
    }
    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }
    public void AddScore()
    {
        
    }
    public void CheckButtonParent()
    {
        indexButton = 0;
        TypeController type = gameObject.GetComponentInChildren<TypeController>();
        if (type == null)
        {
            Debug.Log("hehe");
        }
        Debug.Log("haha");
        type.CheckIndex(indexButton);

    }
    public void CheckButtonGear()
    {
        indexButton = 1;
        TypeController type = gameObject.GetComponentInChildren<TypeController>();
        if (type == null)
        {
            Debug.Log("hehe");
        }
        Debug.Log("haha");
        type.CheckIndex(indexButton);
    }
    void OnTriggerEnter2D()
    {
        GameOver();
    }
}
