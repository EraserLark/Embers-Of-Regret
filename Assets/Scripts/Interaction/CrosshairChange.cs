using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //Uses 'UnityEngine.UI' !!

//Changes crosshair icon/color based on what game object the crosshair is hovered over
public class CrosshairChange : MonoBehaviour
{
    /* Tutorials:
   https://www.youtube.com/watch?v=THnivyG0Mvo - Brackeys Raycast
   https://www.youtube.com/watch?v=iUeNteddnsw - For Crosshair change
   */

    public Camera playerCamera;     //Reference to Camera
    RaycastHit hit;                 //Variable that stores info about the raycast collision / object ray collides with

    public GameObject crosshair;    //Reference to the crosshair in the UI
    public CrosshairImgSwap crossImgSwap;

    void Update()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))  //Want to include a length limit for this?
        {
            string hitTag = hit.transform.tag;      //Var that stores the tag of the object hit, for reference in the statements below

            switch (hitTag)
            {
                case "Item":
                    crossImgSwap.SwapImg(1);
                    break;

                case "Spot":
                    crossImgSwap.SwapImg(2);
                    break;

                case "Note":
                    crossImgSwap.SwapImg(3);
                    break;

                case "Candle":
                    crossImgSwap.SwapImg(4);
                    break;

                case "Lock":
                    crossImgSwap.SwapImg(5);
                    break;

                default:
                    crossImgSwap.SwapImg(0);
                    break;
            }
            /*
            //Create seperate array, run only one 'crosshair.GetComponent<Image>.etc' at the end?
            if (hitTag == "Untagged")
            {
                crosshair.GetComponent<Image>().color = Color.white;    //Set Crosshair color to White (Can't interact)
            }
            else if(hitTag == "Spot")
            {
                crosshair.GetComponent<Image>().color = Color.red;      //Set Crosshair color to Red (Can interact)
            }
            else if (hitTag == "Item")
            {
                crosshair.GetComponent<Image>().color = Color.green;      //Set Crosshair color to Green (Indicates Item - temporary)
            }
            else if (hitTag == "Lock")
            {
                crosshair.GetComponent<Image>().color = Color.yellow;      //Set Crosshair color to Yellow (Indicates a Lock - temp)
            }
            else if (hitTag == "Candle")
            {
                crosshair.GetComponent<Image>().color = Color.magenta;      //Set Crosshair color to Yellow (Indicates a Lock - temp)
            }
            */
        }
        else
        {
            crossImgSwap.SwapImg(0);
            //crosshair.GetComponent<Image>().color = Color.white;    //Set Crosshair color to White (Can't interact)
        }
    }
}
