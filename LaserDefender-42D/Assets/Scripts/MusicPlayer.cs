using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    /* Awake() is a built-in method which is very similar to the Start() built-in method. The Start() method is
     * called in the beginning of the game once the object has been set up (initialised and all components loaded).
     * The Awake is called even before since it is called as soon as the compiler notices the object and is 
     * called before it is initialised and set up.
     */
    private void Awake()
    {
        SetUpSingleton();
    }

    /* Singleton is a principle which ensures that there can be only one copy/instance of an object at a time.
     * For this game, we need to have only one music player so that the same background music is player throughout
     * all of the scenes.
     */
    void SetUpSingleton()
    {
        /*FindObjectsOfType<> returns a LIST of objects which contain the script indicated by <> so a list of
         * music players will return
         * If the list contains more than one music player..
         */
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            //then destroy the new music player
            Destroy(gameObject);
        }
        else
        {
            /* When switching scenes, all of the objects found in the hierarchy of the previous scene are 
             * destroyed so that the objects in the hierarchy of the new scene can be loaded.
             * DontDestroyOnLoad() is a method which does not allow the compiler to destroy the object, passed as 
             * a parameter, once a new scene is loaded.
            */
            DontDestroyOnLoad(gameObject);
        }
    }
}
