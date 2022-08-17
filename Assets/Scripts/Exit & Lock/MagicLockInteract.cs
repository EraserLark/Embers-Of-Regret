using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLockInteract : ItemInteractable   // ItemInteractable << ObjectInteractable << Monobehavior
{
    LockBase lockBase;

    public int lockNum = 0;
    public bool unlocked = false;

    AudioSource doorSource;
    public GameObject door;

    public override void Awake()
    {
        base.Awake();

        lockBase = gameObject.GetComponentInParent<LockBase>();

        doorSource = door.GetComponent<AudioSource>();
    }

    private void Start()
    {
        if(unlocked)
        {
            gameObject.SetActive(false);
            lockBase.Unlocked(gameObject.name);
        }
    }

    public override void ItemSelected()
    {
        base.ItemSelected();

        if(correctItem)
        {
            unlocked = true;
            print(gameObject.name);
            lockBase.Unlocked(gameObject.name);
            //Play correct lock sound
            //Lock disappears (fades out/sparkles?)
            gameObject.SetActive(false);
            doorSource.Play();
        }
    }
}
