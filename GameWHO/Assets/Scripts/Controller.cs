using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public GameObject gameOver;
    public GameObject gameStart;
    public GameObject gamePlay;
    public GameObject gamePlayLeft;
    public GameObject gamePlayRight;
    public bool gOver = false;
    public Text textScore;
    public Text textScoreOver;
    public Text hightScore;

    public int score;

    private GamePlay gamePlayControlLeft;
    private GamePlay gamePlayControlRight;
    
	// Use this for initialization
	void Start () {
        score = 0;
        gamePlayControlLeft = gamePlayLeft.GetComponent<GamePlay>();
        gamePlayControlRight = gamePlayRight.GetComponent<GamePlay>();
	}
	
	// Update is called once per frame
	void Update () {
        AddScore();
	}
    public void GameOver()
    {   
        gameOver.active = true;
        gamePlayControlLeft.GameRelay();
        gamePlayControlRight.GameRelay();
        textScoreOver.text = score.ToString();
        SaveScore();
    }
    public void AddScore()
    {        
        textScore.text = score.ToString();
    }
    public void GameStart()
    {
        gamePlay.active = true;
        gameStart.active = false;
    }
    public void RelayGame()
    {
        gameOver.active = false;
        gOver = false;
        score = 0;

        gamePlayControlLeft.RandomType();
        gamePlayControlRight.RandomType();
        
    }
    void SaveScore()
    {
        if (score > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score",score);
        }
        hightScore.text = PlayerPrefs.GetInt("score").ToString();
    }
}
