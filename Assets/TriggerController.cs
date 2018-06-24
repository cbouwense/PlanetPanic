using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {

    private GameObject blackHole;
    private bool smaller = false;
    private PlanetInfo pi;

    void Start()
    {
        blackHole = GameObject.Find("BlackHole");
        pi = GetComponent<PlanetInfo>();
    }

	void Update ()
    {
		if (!smaller)
        {
            if (pi.mass < blackHole.transform.root.gameObject.GetComponent<Rigidbody2D>().mass)
            {
                smaller = true;
                GetComponent<Rigidbody2D>().isKinematic = false;
            }
            else
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
	}
}
