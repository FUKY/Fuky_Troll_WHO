using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GamePlay : MonoBehaviour {

    public GameObject[] listTypeParent;
    public GameObject[] listGear;
    public RectTransform rectTransform;
    public Transform transform;
    public int indexButton = 0;
    public int score;
    private Controller control;
    public GameObject canVas;
    public List<GameObject> listType;

    public float timeDelayRandom;
    private float timeDelay = 0;
    public float deltaTimeDelay;

    void Awake()
    {
        listType = new List<GameObject>();
        score = 0;
    }
    // Use this for initialization
    void Start()
    {
        control = canVas.GetComponent<Controller>();
        if (control == null)
        {
            Debug.Log("chua co Canvas");
        }
        float deltaTimeDelayCur = Random.Range(0, deltaTimeDelay);
        timeDelay = deltaTimeDelayCur;
    }

    // Update is called once per frame
    void Update()
    {
        if (control.gOver == false)
        {
            if (timeDelay > timeDelayRandom)
            {
                RandomType();
                float deltaTimeDelayCur = Random.Range(0, deltaTimeDelay);
                //Debug.Log(System.String.Format("Time deltaCurrent = {0}", deltaTimeDelayCur));
                timeDelay = deltaTimeDelayCur;
            }
            timeDelay += Time.deltaTime;
        }
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
            //Debug.Log(System.String.Format("floatRigidbody = {0}", type.GetComponent<TypeController>().floatRigidbody));
            listType.Add(type);
            
        }
        if(index == 1)
        {
            indexGear = Random.Range(0, 3);
            GameObject type = Instantiate(listGear[indexGear], transform.position, Quaternion.identity) as GameObject;
            type.transform.SetParent(rectTransform);
            //type.transform.localPosition = Vector3.zero;
            type.transform.localScale = Vector3.one;
            type.GetComponent<TypeController>().inDex = index;
            Debug.Log(System.String.Format("floatRigidbody = {0}", type.GetComponent<TypeController>().floatRigidbody));

            listType.Add(type);
        }
        
    }
    public void GameOver()
    {
        control.gOver = true;
        for (int i = 0; i < listType.Count; i++)
        {
            Destroy(listType[i]);
        }
        listType.Clear();
        control.GameOver();

    }
    [ContextMenu("GameRelay")]
    public void GameRelay()
    {
        for (int i = 0; i < listType.Count; i++)
        {
            Destroy(listType[i]);
        }
        listType.Clear();
    }
    public void AddScore()
    {
        TypeController type = gameObject.GetComponentInChildren<TypeController>();
        control.score += type.diem;     
    }
    public void CheckButtonParent()
    {
        indexButton = 0;
        TypeController type = listType[0].GetComponent<TypeController>();        
        type.CheckIndex(indexButton);
        SwapListType();

    }
    public void CheckButtonGear()
    {
        indexButton = 1;
        TypeController type = listType[0].GetComponent<TypeController>();        
        type.CheckIndex(indexButton);
        SwapListType();
    }
    public void SwapListType()
    {
        if (control.gOver == false)
        {
            for (int i = 0; i < listType.Count - 1; i++)
            {
                for (int j = i + 1; j < listType.Count; j++)
                {
                    listType[i] = listType[j];
                }
            }
            listType.RemoveAt(listType.Count - 1);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        GameOver();
    }
}
