using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeHandle : ObjectInteractable
{
    public int numOfCorrectDials = 0;
    bool refreshCalled = false;

    public GameObject safeDoor;
    public GameObject dials;
    public AudioSource knobSource;

    public override void Selected()
    {
        //base.Selected();

        knobSource.Play();

        if(numOfCorrectDials >= 4)
        {
            //Open Safe
            //print("Safe unlocked!!");     //DEBUG

            safeDoor.GetComponent<AudioSource>().Play();    //Play safe door opening sound effect

            safeDoor.transform.eulerAngles = new Vector3(90, 90, 0);    //Flips door open -- Animate opening instead??
            dials.SetActive(false);
        }
        else
        {
            if (refreshCalled)
            {
                CancelInvoke("Refresh");
            }
            //Play Incorrect lock sound
            refreshCalled = true;
            gameObject.tag = "Lock";
            Invoke("Refresh", 3f);
        }
    }

    private void Refresh()
    {
        gameObject.tag = "Item";
        refreshCalled = false;
    }
}
