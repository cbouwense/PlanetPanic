using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : PhysicsObject {

    public GameObject blackHole;

	// Use this for initialization
	new void Start ()
    {
        base.Start();

	}
	
	// Update is called once per frame
	new void Update ()
    {
        base.Update();

	}

    bool isBiggerThanBlackHole()
    {
        // TODO: temp value
        return true;
    }
    
}
