using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter; //holding the random time before the next laser shot
    [SerializeField] float minTimeBetweenShots = 0.2f;//possible shortest time between one laser shot and 
    //another
    [SerializeField] float maxTimeBetweenShots = 3f;//possible longest time between one laser shot and 
    //another

    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float enemyLaserSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        //finding a random time for the next (first) laser to shoot
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    /* The OnTriggerEnter2D built-in method is used since one of the colliders which are part of the collision
     * (enemy and player laser) has a trigger collider.
     */
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

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage(); // health = health - damageDealer.GetDamage();
        // A -= B; => A = A - B;

        // health -= collision.gameObject.GetComponent<DamageDealer>().GetDamage();

        if (health <= 0)
            Destroy(gameObject);
    }

    void CountDownAndShoot()
    {
        //The shot counter should count down the time as it is passing by and Time.deltaTime retrieves the
        //time passed from the previous frame. Thus, as frames are being processed, we reduce the actual
        //game time from the shotCounter 
        shotCounter -= Time.deltaTime; //deltaTime returns the time taken for the previous frame to execute

        if (shotCounter <= 0)
        {
            // enemy shoot
            EnemyFire();

            //reset the shotCounter with the next amount of time to wait before the next laser is shot
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    void EnemyFire()
    {
        GameObject enemyLaserClone = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);

        enemyLaserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);
        //enemyLaserSpeed needs to be negative to shoot downwards, otherwise it will shoot upwards.
    }
}
