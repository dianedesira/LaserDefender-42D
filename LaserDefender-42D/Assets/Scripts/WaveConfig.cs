using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Normal scripts are of type MonoBehaviour since they are used to control objects
 * in our scene/hierarchy.
 * 
 * ScriptableObject scripts are used to solve the issue of Prefabs since every time
 * a prefab is cloned, a copy of all the data for the prefab is generated and using
 * up the memory. There are certain values which need to be repeated and copied 
 * for every clone but there is certain values which remain the same for all 
 * prefabs. A ScriptableObject ensures that the specified values are created only
 * once (regardless of how many prefab clones there are) and the values can be 
 * shared by all of the clones.
 */

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    //enemy
    [SerializeField] GameObject enemyPrefab;

    //the path on which to go
    [SerializeField] GameObject pathPrefab;

    //time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //include this random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of enemies in wave
    [SerializeField] int numberOfEnemies = 5;

    //enemy movement speed
    [SerializeField] float enemyMoveSpeed = 2f;

    /* We are going to leave the variables as private so that other scripts cannot
     * access them and change their values. Instead, we created a method for each
     * variable so that its value is returned and thus can be read by other scripts
     * (the variable are READ ONLY). In fact these methods are called getter methods 
     * since they get and return a value.
     */
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}
