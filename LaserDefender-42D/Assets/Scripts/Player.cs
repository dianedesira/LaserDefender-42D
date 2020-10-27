using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
     * In Unity we will be using two type of methods; the Built-in methods and the User-Defined methods
     * 
     * Built-in methods are methods which the Unity compiler knows when to execute them at specific times
     * during game execution.
     * Since C# is case sensitive, it is important that we define these Built-in methods with the proper name
     * and proper case.
     * 
     * User Defined methods are methods which we create to properly organise our code and avoid from having
     * chunks of code in one place. Since Unity doesn't know about these methods we need to remember to
     * call these methods where they are required.
     */

    // Start is called before the first frame update
    void Start() // A common built-in method
    /* Here we have a method definition for the Start method so that the compiler will know what to execute
     * once it is called.
     * A method definition is just an explanation of what the method will do once the method is called.
     * A method definition is made up of the access modifier, return type, method name, brackets to include
     * parameters and curly brackets to hold the different statements.
     */
    {
       // print("The Start built-in method has been called!");
    }

    // Update is called once per frame
    void Update()
    {
      //  print("The Update built-in method is being called!");
    }

    void Move()
    {
        /* format of calling a method with a return
         * variableToStoreReturn = methodCall();
         * 
         * format to call a method which has not been defined in our class
         * ClassName.MethodName();
         */

        var deltaX = Input.GetAxis("Horizontal");
    }
}
