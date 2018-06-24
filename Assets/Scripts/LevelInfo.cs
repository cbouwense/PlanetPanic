using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour {

    public GameObject blackHole;
    public Text massCounter;

    public const int levelNum = 10;
    public float[] massReqs = new float[levelNum];
    public float[] timeReqs = new float[levelNum];

    void Update()
    {
        Debug.Log("setting mass");
        massCounter.text = blackHole.GetComponent<Rigidbody2D>().mass + "/" + massReqs[SceneManager.GetActiveScene().buildIndex];
    }

}
