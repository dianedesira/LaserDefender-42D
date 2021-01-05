using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        /* LoadScene is found in the SceneManager class (which is found in the SceneManagement library - this
         * is required to be imported).
         * There are different ways how to load a scene, the most common are via a number (the sceneBuildIndex)
         * or via a string (the scene Name).
         * Below, we are loading the scene with buildIndex 0, so the first scene in our game - the Start Menu
         */
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //IMP the name should be exactly as the scene is named in the editor
        SceneManager.LoadScene("LaserDefender");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
