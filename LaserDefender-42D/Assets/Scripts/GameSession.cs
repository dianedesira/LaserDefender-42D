using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0; //score will be left as private so that management of this variable will be handled by methods
    //to have more control

    private void Awake()
    {
        /* GameSession is responsible for managing the game score. The game score should be displayed in the 
         * Game Over scene, though, if we simply have a copy of the GameSession in the Game Over scene, while 
         * switching from LaserDefender to the Game Over, the Laser Defender's game session will be destroyed (thus,
         * the achieved score will also be destroyed) and the Game Over's game session will be recreated with an
         * initial score of 0. 
         * We need to make sure that the GameSession is not destroyed when switching scenes but then we also need
         * to ensure that we only have one instance of GameSession at a time - thus, the Singleton principle is
         * requiredto be applied.
         */
        SetUpSingleton();
    }

    void SetUpSingleton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    //when AddToScore() is called, the scoreValue to be added to the score should be passed as a parameter since
    //we may have a situation where different enemies have different scores once killed
    public void AddToScore(int scoreValue)
    {
        score += scoreValue; // score = score + scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
