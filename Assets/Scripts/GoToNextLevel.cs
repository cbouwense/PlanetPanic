using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {

    public GameObject sceneUtils;
    private TimerController timer;
    
    void Start()
    {
        sceneUtils = GameObject.Find("SceneUtils");
        timer = sceneUtils.GetComponent<TimerController>();
    }

	private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Something collided with the goal!");

        // Check if it's the blackhole
        if (col.gameObject.tag == "BlackHole")
        {
            // Check if they're big enough to enter
            LevelInfo levelInfo = sceneUtils.GetComponent<LevelInfo>();
            if (col.gameObject.GetComponent<Rigidbody2D>().mass >= levelInfo.massReqs[SceneManager.GetActiveScene().buildIndex])
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void Update()
    {
        if (timer.finished)
        {
            // TODO: UI popup prompting to go reset level, go to menu, or quit
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
            
        }
    }

}
