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
        portraitSource.Play();
        Destroy(portrait);
        Destroy(gameObject);
    }
}
