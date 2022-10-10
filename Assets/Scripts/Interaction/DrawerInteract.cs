using UnityEngine;

public class DrawerInteract : ObjectInteractable
{
    public AudioSource drawerSource;

    public override void Awake()
    {
        drawerSource = gameObject.GetComponent<AudioSource>();
    }

    public override void Selected()
    {
        base.Selected();

        if(state)
        {
            gameObject.transform.Translate(Vector3.right * 10, Space.Self);
            drawerSource.Play();
        }
        else if(!state)
        {
            gameObject.transform.Translate(Vector3.left * 10, Space.Self);
        }
    }
}
