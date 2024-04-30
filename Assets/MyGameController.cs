using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameController : MonoBehaviour
{
    private int scoreLeft;
    private int scoreRight;

    public GameObject Ball;
    private MyBallController myBallCtrllr;

    public Text leftScoreText;
    public Text rightScoreText;
    public Text Winscreen;

    public int interval = 0;
    private bool started = false;

    Vector3 ballStartingPos;
    // Start is called before the first frame update
    void Start()
    {
       myBallCtrllr= Ball.GetComponent<MyBallController>();
        ballStartingPos = Ball.transform.position;
    }
    void resetBall()
    {
        myBallCtrllr.stopMove();
        Ball.transform.position= ballStartingPos;
        started = false;
    }
    void increasespeed()
    {
        int rdmspeed=Random.Range(1,5);
        myBallCtrllr.speed += rdmspeed;
    }
    public void ScoreRightGoal()
    {
        resetBall();
        Debug.Log("a goal scored in the right!");
        scoreLeft++;
        updateUI();
    }
    public void ScoreLeftGoal()
    {
        resetBall();
        Debug.Log("a goal scored in the left!");
        scoreRight++;
        updateUI();
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        interval++;
        if (!started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                started = true;
                myBallCtrllr.startMove();
            }
        }
        if(interval>=2000)
        {
            increasespeed();
            interval = 0;
        }
        if(scoreLeft>=5)
        {
            PauseGame();
            Winscreen.text = "Player 1 Wins";
            Winscreen.gameObject.SetActive(true);

        }
        if (scoreRight >= 5)
        {
            PauseGame();
            Winscreen.text = "Player 2 Wins";
            Winscreen.gameObject.SetActive(true);

        }
    }
    void updateUI()
    {
        resetBall();
        leftScoreText.text = scoreLeft.ToString();
        rightScoreText.text = scoreRight.ToString();

    }




}
