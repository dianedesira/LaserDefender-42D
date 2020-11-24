using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //a list of WaveConfigs - multiple waves which represent different enemy groups
    [SerializeField] List<WaveConfig> waveConfigs;

    //variable to keep track of current wave/group which we are working with
    int startingWave = 0; // first item always in position 0 of a list

    // Start is called before the first frame update
    void Start()
    {
        //The first wave which will be generated will be the one in position 0 in the
        //waveConfigs list
        WaveConfig currentWave = waveConfigs[startingWave];

        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Although, there are different ways how this could have been handled, the 
     * SpawnAllEnemiesInWave coroutine is an example of creating a method with a parameter.
     * The reason that parameters are used is since their values will most probably change
     * from one method call to another. In our case, the parameter represents the wave 
     * configuration asset and for different groups of enemies, to spawn, the specific
     * wave configuration will be different (basically we will be fetching the different
     * wave configs from the waveConfigs list - starting with first and traversing the rest)
     */
    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        /* A repetition was created so that the cloning of the enemies is repeated depending
         * on the value of numberOfEnemies for the particular wave (since different groups can
         * have different amount of enemies).
         */
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            /*Since each waveConfig will have different values for the different enemy groups,
             * we are fetching the necessary group info from the waveConfig and not directly
             * from our project panel.
             * For the first position of the clone, we are placing the clone on the first way
             * point of the current path. The method GetWaypoints returns a list of Transform
             * components and we always retrieve the position from the transform component.
             * Thus, waveConfig.GetWaypoints()[0] is retrieving the first transform in the list
             * and with .position we are fetching the position property from the transform
             * (rather than the rotation and scale).
             */
            GameObject newEnemyClone = Instantiate(waveConfig.GetEnemyPrefab(), 
                                                   waveConfig.GetWaypoints()[0].position,
                                                   Quaternion.identity);

            //for this current enemy clone, we are indicating in which wave/group it is in
            //thus, from EnemyPathing it can retrieve the proper path and move it along that
            //path
            newEnemyClone.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
