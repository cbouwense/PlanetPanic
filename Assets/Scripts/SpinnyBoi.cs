using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyBoi : MonoBehaviour {

	void Update()
    {
        GetComponent<Rigidbody2D>().angularVelocity = -20;
    }

}
