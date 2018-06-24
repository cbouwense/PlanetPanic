using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consume : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Check if object is consumable
        if (col.gameObject.tag == "Planet" && col.transform.localScale.x < transform.localScale.x)
        {
            Absorb(col.gameObject);
        }
    }

    private void Absorb(GameObject target)
    {
        Debug.Log("Consuming " + target.name);

        // Increase scale of black hole.
        float newXScale = transform.parent.transform.localScale.x + (target.transform.localScale.x * 0.5f);
        float newYScale = transform.parent.transform.localScale.y + (target.transform.localScale.y * 0.5f);
        transform.parent.transform.localScale = new Vector2(newXScale, newYScale);

        // Increase mass of black hole.
        transform.parent.GetComponent<Rigidbody2D>().mass += target.GetComponent<Rigidbody2D>().mass * 0.5f;

        // Get rid of thing we collided with.
        Destroy(target);
    }

}
