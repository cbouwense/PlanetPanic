using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    private List<GameObject> bodyList;
    // TODO: make this something meaningful eventually
    protected const float G = 100.0f;

/**  //////   ///    ///  ///////////  ///////////
 *  ///  ///  ///    ///  ///     ///  ///     ///
 *  ///       ///    ///  ///          ///
 *   //////   ///    ///  ///          ///
 *       ///  ///    ///  ///          ///
 *  ///  ///  //////////  ///     ///  ///     ///
 *   //////   //////////  ///////////  ///////////
 */ 
    void succ(GameObject target)
    {
        // Calculate force due to gravity
        Rigidbody2D myRB = transform.parent.GetComponent<Rigidbody2D>();
        float radius = Vector2.Distance(target.transform.position, transform.position);
        float gravForce = G * myRB.mass * target.GetComponent<Rigidbody2D>().mass / Mathf.Pow(radius, 2);

        // Get vector from target to us
        Vector2 target2Us = transform.position - target.transform.position;
        Vector2 succForce = target2Us.normalized * gravForce;

        // Apply the force to the black hole
        target.GetComponent<Rigidbody2D>().AddForce(succForce);
    }

    void Start()
    {
        bodyList = new List<GameObject>();
    }

    void FixedUpdate()
    {
        foreach (GameObject body in bodyList)
        {
            // Only succ if it's black hole on planet action
            if (!(tag == "Planet" && body.tag == "Planet"))
            {
                Debug.Log(this.name + " is succing " + body.name);
                succ(body);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Planet" && col.gameObject.GetComponent<Rigidbody2D>())
        {
            succ(col.gameObject);
        }
            
    }
    
    private bool targetIsSmaller(Rigidbody2D target)
    {
        Transform targetTransform = target.transform;
        Debug.Log("targetTransform: " + targetTransform);

        // Everything is a circle so we only have to check one dimension
        if (targetTransform.localScale.x < transform.localScale.x)
        {
            Debug.Log(target.gameObject.name + " is smaller than " + this.name);
            return true;
        }
        else
        {
            return false;
        }
    }

}
