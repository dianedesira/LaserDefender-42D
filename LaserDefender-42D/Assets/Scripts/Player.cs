using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializeField allows to to keep my elements private but still access them in
    // the Unity Editor.
    [SerializeField] float movementSpeed = 10f;

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
        Move();
    }

    void Move()// method definition
    {
        /* format of calling a method with a return
         * variableToStoreReturn = methodCall();
         * 
         * format to call a method which has not been defined in our class
         * ClassName.MethodName();
         */

        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed; 
        // any method which returns a value should be assigned to a variable so that the value is stored and not lost.
        
        /* deltaTime is a property which returns the time taken for the previous frame to execute.
         * Since different devices have different frame rates, to make the game frame INDEPENDANT, we are
         * multiplying the distance generated (depending on the amount of frames) with the frame duration
         * and thus, cancelling out the frame rate value.
         */


        /*
         * The GetAxis() method will search from the axis passed as a parameter, and will check what user
         * controls are set e.g. arrow keys and keyboard keys. If the user, presses on any of these keys
         * a value to represent the movement/control is returned.
         */

        /* To change a setting/property for our object, from the code, we need to use the format
         * object.component.property
         * If the script is controlling the object we need, we can ignore the object in the syntax and use
         * component.property
         */

        //calculating the new x coordinate by fetching the current x and adding/deducting the value of deltaX
        var newXPos = transform.position.x + deltaX;

        //calling the Player's position property:
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
    }
}
