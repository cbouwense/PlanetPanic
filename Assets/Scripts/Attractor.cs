using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
    
    protected const float G = 10.0f;
    private List<GameObject> bodyList;

    private void Start()
    {
        bodyList = new List<GameObject>();
    }

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
        Debug.Log("I'm " + transform.parent.name + " succing " + target.name);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!(tag == "Planet" && col.gameObject.tag == "Planet") && col.transform.parent.gameObject.GetComponent<Rigidbody2D>())
        {
            Debug.Log("Added " + col.name + " to bodylist");
            bodyList.Add(col.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Removed " + col.name + " from bodylist");
        bodyList.Remove(col.transform.parent.gameObject);
    }

    private void FixedUpdate()
    {
        foreach (GameObject body in bodyList)
        {
            Debug.Log(this.name + " is succing " + body.name);
            succ(body);
        }
    }

}
