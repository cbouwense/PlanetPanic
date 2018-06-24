using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
    
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

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Planet" && col.gameObject.GetComponent<Rigidbody2D>())
        {
            succ(col.gameObject);
        } 
    }

}
