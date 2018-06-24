using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    private LevelInfo levelInfo;
    public Text timerText;
    private float timeLimit;
    public bool finished = false;
    public float t;

    private void Start()
    {
        levelInfo = GetComponent<LevelInfo>();
        Debug.Log("level time req: " + levelInfo.timeReqs[SceneManager.GetActiveScene().buildIndex]);
        t = levelInfo.timeReqs[SceneManager.GetActiveScene().buildIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return; 

        t -= Time.deltaTime;

        if (t <= 0)
        {
            Finish();
            return;
        }

        string minutes = ((int)t / 60).ToString();
        if ((int)t / 60 < 10)
        {
            minutes = "0" + minutes;
        }
        string seconds = (t % 60).ToString("f2");
        if (t % 60 < 10)
            seconds = "0" + seconds;

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
        finished = true;
        timerText.text = "00:00.00";
        timerText.color = Color.red;
    }

    public void Reset()
    {
        timeLimit = levelInfo.timeReqs[SceneManager.GetActiveScene().buildIndex];
        finished = false;
        Debug.Log("In Reset(), timelimit: " + timeLimit + " | finished: " + finished);
    }

    public bool isTimeUp()
    {
        return finished;
    }

}

