using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearDownPortrait : ObjectInteractable
{
    public AudioSource portraitSource;
    public GameObject portrait;

    public override void Awake()
    {
        portraitSource = gameObject.GetComponentInParent<AudioSource>();
    }

    public override void Selected()
    {
        //base.Selected();

        portraitSource.Play();        //play tear sound
        Destroy(portrait);
        Destroy(gameObject);
    }
}
