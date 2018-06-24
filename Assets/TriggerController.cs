using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {

    private GameObject blackHole;
    private bool smaller = false;

    void Start()
    {
        blackHole = GameObject.Find("BlackHole");
    }

	void Update ()
    {
		if (!smaller)
        {
            if (transform.localScale.x < blackHole.transform.localScale.x)
            {
                smaller = true;
                GetComponent<CircleCollider2D>().isTrigger = true;
            }
        }
	}
}
