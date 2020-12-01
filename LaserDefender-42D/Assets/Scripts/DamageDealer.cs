using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;

    public int GetDamage() //getter method to fetch only the value for the damage variable without giving 
        //access to the actual variable
    {
        return damage;
    }
    /* This method has been generated so that as soon as the type of laser hits anything, this can be called
     * so that the laser is destroyed and not seen passing through the object it hit.
     */
    public void Hit()
    {
        /* The gameObject keyword refers to the current object which contains this script (which object this 
         * script is attached to)
         */
        Destroy(gameObject);
    }

}
