using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShotController : MonoBehaviour {

    private GameObject myLine;
    private float hitForceConstant = 30.0f;

    void OnMouseDown()
    {
        myLine = new GameObject();
    }

    void OnMouseDrag()
    {
        // Draw a dotted line between your cursor and the black hole.
        myLine.transform.position = transform.position;
        myLine.AddComponent<LineRenderer>();

        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(Color.white, Color.red);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, transform.position);
        Vector2 mouseCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        /* TODO: this is to make it only go so far
        Vector2 displacement = mouseCoords - (Vector2)transform.position;
        if (displacement.magnitude > 5)
        {
            lr.SetPosition(1, displacement.normalized * 5);
        }
        else
        {
            lr.SetPosition(1, mouseCoords);
        }
        */
        lr.SetPosition(1, mouseCoords);
    }
    
    void OnMouseUp()
    {
        // Stop drawing the line.
        GameObject.Destroy(myLine);

        // Stop the black hole from moving.
        GetComponent<Rigidbody2D>().velocity = new Vector2();

        // Calculate a force vector to hit the ball with.
        Vector3 mouseCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 hitForce = (transform.position - mouseCoords) * hitForceConstant;

        // Hit the ball with the force vector.
        GetComponent<Rigidbody2D>().AddForce(hitForce);

        // TODO: Maybe do some hitting animation.

    }

}
