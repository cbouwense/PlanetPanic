using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBlackHole : MonoBehaviour {
    
    public GameObject blackHole;
    
    private void Start()
    {
        blackHole = GameObject.Find("BlackHole");
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(blackHole.transform.position.x,
                                         blackHole.transform.position.y,
                                         transform.position.z);
        GetComponent<Camera>().orthographicSize = blackHole.transform.root.localScale.x + 8;
    }
}
