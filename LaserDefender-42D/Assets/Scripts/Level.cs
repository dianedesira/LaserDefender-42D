using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

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
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        print("quitting game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad()
    {
        /* So as not to immediately load the Game Over scene, when the player dies, a delay will be used so 
         * that the user will realise that the player has now died.
         * As soon as the compiler enters this method, it needs to return back and come back after the delay is
         * over so that the Game over scene can be loaded.
         */
        yield return new WaitForSeconds(delayInSeconds);

        SceneManager.LoadScene("GameOver");
    }
}
