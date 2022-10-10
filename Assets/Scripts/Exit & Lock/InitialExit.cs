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
        gameObject.tag = "Lock";

        if(lockBase.firstPlay == true && firstClick == true)
        {
            firstClick = false;
            magicLock.SetActive(true);
            magicLock.gameObject.GetComponent<Animator>().Play("LockAppear");
        }

        if(lockBase.allUnlocked)
        {
            AudioSource.PlayClipAtPoint(doorOpen, gameObject.transform.position, 50f);

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
