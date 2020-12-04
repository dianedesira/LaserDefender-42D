using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializeField allows to to keep my elements private but still access them in
    // the Unity Editor.
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringTime = 0.3f;

    [SerializeField] GameObject laserPrefab;
    Coroutine fireRoutine;

    [SerializeField] float health = 100;


    float padding = 0.5f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

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
        SetUpMoveBoundaries();

       // StartCoroutine(PrintAndWait());
    }

    // Update is called once per frame
    void Update()
    {
        //  print("The Update built-in method is being called!");
        Move();
        Fire();
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
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        //calling the Player's position property:
        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
    }

    void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        /*
         * ViewportportToWorldPoint looks at the current view of the camera and sets the boundaries
         * between 0 and 1 at runtime. Thus, if we change the camera size, the new boundaries are recalculated
         * with the same values of min 0 and max 1.
         * Currently they have specific values and if we use these we need to change them everytime the
         * camera is changed.
         */

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    void Fire()
    {
        /*
         * GetButtonDown returns true as soon as the user presses down on the specified
         * button. In our settings Fire1 represents the left mouse button click (mouse 0)
         * The method is executed ONLY once as soon as the button is pressed. To keep
         * executing, the user needs to keep tapping on the button.
         */

        if (Input.GetButtonDown("Fire1")) // if(Input.GetButtonDown("Fire1")) == true)
        {
            fireRoutine = StartCoroutine(FireContinously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireRoutine);
            // if we don't stop the coroutine, new coroutines will be constantly created
        }
    }

    /*   IEnumerator PrintAndWait()
       {
           print("Message 1 sent!");

           yield return new WaitForSeconds(3f);

           print("Message 2 sent!");
       }
    */

    IEnumerator FireContinously()
    {
        while (true)
        {
            /* The Instantiate method creates (and returns) a clone from the object passed as the 
             * first parameter. The position passed as the 2nd parameter will indicate where
             * the clone needs to be placed in the scene.
             * Quaternion.identity represents no rotation given to the object.
             */

            GameObject laserClone = Instantiate(laserPrefab, this.transform.position,
                Quaternion.identity);

            // the velocity property is part of the rigidbody2D component
            laserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            /*We are using coroutines so that we create a short delay between the generation
             * of one laser and another (since we are in an infinite loop). The advantage
             * of using coroutines, is that during the delay, the method process will return
             * and continue with other processes and get back to the method once the delay
             * is up. If the method process does not return back, all of the application
             * would be stuck until the method continues after the delay.
             * 
             * yield return is the keyword which indicates that the process needs to pause
             * from this method execution, return and get back exactly to where it left off.
             * The time or the reason when to get back is indicated by new WaitForSeconds
             * or new WaitUntil or new WaitWhile etc basically it's either a time delay or
             * waiting for a condition to be met.
             */
            yield return new WaitForSeconds(projectileFiringTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* The damage that needs to be applied to the enemy's health is found in the DamageDealer script and
         * this script is attached to the player laser clone.
         * Thus, to fetch the method from the script we need to use the syntax of object.component.element
         * the laser clone is the other object part of the collision thus, collision.gameObject
         * GetComponent<DamageDealer>() retrieves the script component and from the component we call the
         * method.
         */
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer)
            return;

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage(); // health = health - damageDealer.GetDamage();
        // A -= B; => A = A - B;
        damageDealer.Hit();
        // health -= collision.gameObject.GetComponent<DamageDealer>().GetDamage();

        if (health <= 0)
            Destroy(gameObject);
    }
}
