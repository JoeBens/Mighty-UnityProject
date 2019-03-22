using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    private Transform mainCam; // The Main Camera.
    public Transform[] backgrounds; // The list of al the background textures that will be used by the Parallax effect.
    private Vector3 startCamPos;// the initial position of the Camera.
    private float[] parallaxSize;// The proportion of the camera's movement to move the backgrounds.
    [Range(0.0f, 5.0f)] // Slide Bar.
    public float smoothHorizontal = 0.8f;// The smooth speed of the Horizontal Parallax Movement.
    [Range(0.0f, 5.0f)]  // Slide Bar.
    public float smoothVertical = 0.2f; // The smooth speed of the Vertical Parallax Movement.
    private bool xParallax = true;// Horizontal Parallax Effect (Left/Right).
    private bool yParallax = true;//Vertical Parallax Effect (Up/Down).



    void Start()
    {

        mainCam = Camera.main.transform;//Main Camera reference.
        startCamPos = mainCam.position; // Set the position of the Main Camera when the scene is loaded.

        // Asign the coresponding Parallax Size.
        parallaxSize = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxSize[i] = backgrounds[i].position.z * -1;
        }
    }


    void LateUpdate()
    {


        if (xParallax)
        { // if the parallax effect is horizontal.

            // for each background
            for (int i = 0; i < backgrounds.Length; i++)
            {
                // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
                float parallax = (startCamPos.x - mainCam.position.x) * parallaxSize[i];
                // set a target x position which is the current position plus the parallax
                float backgroundTargetPosX = backgrounds[i].position.x + parallax;
                // create a target position which is the background's current position with it's target x position
                Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
                // fade between current position and the target position using lerp
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothHorizontal * Time.deltaTime * 10);
            }


        }
        if (yParallax) //if the parallax effect is vertical.
        {
            // for each background
            for (int i = 0; i < backgrounds.Length; i++)
            {
                // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
                float parallax = (startCamPos.y - mainCam.position.y) * parallaxSize[i];
                // set a target x position which is the current position plus the parallax
                float backgroundTargetPosY = backgrounds[i].position.y + parallax;
                // create a target position which is the background's current position with it's target x position
                Vector3 backgroundTargetPos = new Vector3(backgrounds[i].position.x, backgroundTargetPosY, backgrounds[i].position.z);
                // fade between current position and the target position using lerp
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothVertical * Time.deltaTime * 10);
            }


        }
        startCamPos = mainCam.position; // set the startCamPos to the camera's position at the end of the frame

    }
}
