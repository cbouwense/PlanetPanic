using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBlackHole : MonoBehaviour {
    
    public GameObject blackHole;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(blackHole.transform.position.x,
                                         blackHole.transform.position.y,
                                         transform.position.z);
	}
}
