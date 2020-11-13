using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * OnTriggerEnter2D() is a built-in method which is executed as soon as this object's
     * collider (the shredder's collider) hits another collider.
     * OnTriggerEnter2D() is used when the current collider has is Trigger ticked. Otherwise,
     * we would need to use OnCollisionEnter2D()
     * This built in method has a parameter of type Collider2D which stores all of the info
     * about the collision which has just occurred. This includes the object which has just
     * hit our object.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject represents the other object which hit the current collider
        // In our case it can only be the laser
        Destroy(collision.gameObject);
        // The Destroy() method destroys the gameObject which is passed as a parameter from
        // the hierarchy
    }

}
