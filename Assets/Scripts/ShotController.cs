using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShotController : MonoBehaviour {

    public GameObject blackHole;
    private GameObject myLine;
    private float hitForceConstant = 30.0f;

    private void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            Debug.Log("GOUT MOUSE DOWN DFJL:DSKFJSDKL:FDSFJ");
            myLine = new GameObject();
        }

        if (UnityEngine.Input.GetMouseButton(0))
        {
            // Draw a line between your cursor and the black hole.
            myLine.transform.position = blackHole.transform.position;
            myLine.AddComponent<LineRenderer>();

            LineRenderer lr = myLine.GetComponent<LineRenderer>();
            lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
            lr.SetColors(Color.white, Color.red);
            lr.SetWidth(0.1f, 0.1f);
            lr.SetPosition(0, blackHole.transform.position);
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

        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            // Stop drawing the line.
            GameObject.Destroy(myLine);

            // Stop the black hole from moving.
            blackHole.GetComponent<Rigidbody2D>().velocity = new Vector2();

            // Calculate a force vector to hit the ball with.
            Vector3 mouseCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 hitForce = (blackHole.transform.position - mouseCoords) * hitForceConstant;

            // Hit the ball with the force vector.
            blackHole.GetComponent<Rigidbody2D>().AddForce(hitForce);

            // TODO: Maybe do some hitting animation.
        }

    }

}
