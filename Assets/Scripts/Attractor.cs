using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    private List<Rigidbody2D> bodyList;
    // TODO: make this something meaningful eventually
    protected const float G = 10.0f;

/**  //////   ///    ///  ///////////  ///////////
 *  ///  ///  ///    ///  ///     ///  ///     ///
 *  ///       ///    ///  ///          ///
 *   //////   ///    ///  ///          ///
 *       ///  ///    ///  ///          ///
 *  ///  ///  //////////  ///     ///  ///     ///
 *   //////   //////////  ///////////  ///////////
 */ 
    void succ(Rigidbody2D target)
    {
        // Calculate force due to gravity
        Rigidbody2D myRB = this.GetComponent<Rigidbody2D>();
        float radius = Vector2.Distance(target.transform.position, transform.position);
        float gravForce = G * myRB.mass * target.mass / Mathf.Pow(radius, 2);

        // Get vector from target to us
        Vector2 target2Us = transform.position - target.transform.position;
        Vector2 succForce = target2Us.normalized * gravForce;

        // Apply the force to the black hole
        target.GetComponent<Rigidbody2D>().AddForce(succForce);
    }

    void Start()
    {
        bodyList = new List<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        foreach (Rigidbody2D body in bodyList)
        {
            Debug.Log(this.name + " is succing " + body.name);
            succ(body);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " entered " + this.name + "'s sphere of influence");
        bodyList.Add(col.gameObject.GetComponent<Rigidbody2D>());
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " exited " + this.name + "'s sphere of influence");
        bodyList.Remove(col.gameObject.GetComponent<Rigidbody2D>());
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
