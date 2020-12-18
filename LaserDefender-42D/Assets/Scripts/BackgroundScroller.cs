using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f; // the speed for the scrolling of the background
    Material myMaterial; // the material to scroll - the value will be initialised by a method. Methods
    //cannot be called from outside another method/function, thus, globally we can only declare it at this
    //point
    Vector2 offSet; // used to control the movement for the image/material

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material; //fetching the required material from the Mesh
        //Renderer component in our current object, Background.

        offSet = new Vector2(0f, backgroundScrollSpeed); // scrolling is only done vertically on the y-axis.
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime; //During every frame, the background's 
        //material will be moved via the set offset and to set it frame independent we are multiplying by
        //the time taken for the previous frame.
    }
}
