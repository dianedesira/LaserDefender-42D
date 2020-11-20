using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //a list of WaveConfigs - multiple waves which represent different enemy groups
    [SerializeField] List<WaveConfig> waveConfigs;

    //variable to keep track of current wave which we are working with
    int startingWave = 0; // first item always in position 0 of a list

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
