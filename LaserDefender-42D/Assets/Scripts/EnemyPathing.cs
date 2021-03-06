﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //reference to the asset item in the project panel which is of type WaveConfig/
    //Enemy Wave Config
    WaveConfig waveConfig;

    List<Transform> waypoints;

    int wayPointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints(); //fetch the method GetWaypoints() from our
        //current wave (type WaveConfig) to retrieve all of the points found in the current
        // linked path
        transform.position = waypoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        // a check is made to make sure that there are coordinates left to traverse
        // in the list.
        if (wayPointIndex <= waypoints.Count - 1)
        // if(wayPointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[wayPointIndex].transform.position;

            var movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime; 
            //making the enemy movement frame independent (moving at the same speed on every PC).

            /*
             * MoveTowards is a method found in the Vector2 class. This method returns
             * a temporarily coordinate so that it starts moving the object from the
             * current position to the targetposition. Different coordinates are 
             * constantly returned to make the object move "slowly" in a path to the 
             * targetPosition, otherwise, the object would go immediately to the 
             * targetPosition.
             * The value of the coordinate depends on the speed which is passed as the
             * last parameter.
             */

            transform.position = Vector2.MoveTowards(transform.position, targetPosition,
                movementThisFrame);

            //check if current position is equal to that of the destination so that we
            //can start moving towards the next coordinate (if there are any left)
            if (transform.position == targetPosition)
                wayPointIndex++;
        }
        else // if there are no coordinates left in our list, destroy the enemy
        {
            Destroy(gameObject);
        }
    }

    /* The particular wave to set the current waveConfig can only be retrieved from outside the
     * script (in this case, from the EnemySpawner since this is the script which will know the
     * group in which the current enemy is in)
     */
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        /* waveConfig is the global variable for this particular enemy and when an enemy clone
         * is generated, this method (SetWaveConfig()) will be called to indicated in which 
         * wave/group it is in. This is important since depending on the wave it is in, the path
         * will be different. This way, the enemypathing script can work with the proper path
         * for the current wave.
         */
        waveConfig = waveConfigToSet;
    }
}
