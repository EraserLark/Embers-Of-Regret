using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialExit : ObjectInteractable
{
    public LockBase lockBase;
    public GameObject magicLock;
    public GameObject exitColl;
    public GameObject door;

    public AudioClip doorOpen;

    bool firstClick = true;

    public override void Selected()
    {
        //base.Selected();

        gameObject.tag = "Lock";

        if(lockBase.firstPlay == true && firstClick == true)
        {
            firstClick = false;
            magicLock.SetActive(true);
            magicLock.gameObject.GetComponent<Animator>().Play("LockAppear");
        }

   
        //Play magic lock sound

        if(lockBase.allUnlocked)
        {
            AudioSource.PlayClipAtPoint(doorOpen, gameObject.transform.position, 50f);            //Play door opening sound

            magicLock.SetActive(false);
            gameObject.SetActive(false);
            door.SetActive(false);
            exitColl.SetActive(true);
        }
    }

    public void AllUnlocked()
    {
        gameObject.tag = "Item";
    }
}
