using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDial : ObjectInteractable
{
    public float mouseMultiplier = 5f;

    float mouseSpeed;
    float angularVel;
    float cubeRotDeg;

    Rigidbody r;
    AudioSource dialSource;

    public override void Awake()
    {
        r = gameObject.GetComponent<Rigidbody>();
        //dialSource = gameObject.GetComponent<AudioSource>();      //For playing squeaking sounds, still not worked out yet
    }

    public override void Selected()
    {
        StartCoroutine(SpinDial()); //Replaces 'OnMouseDrag()', runs while mouse is held down (see below)
    }

    IEnumerator SpinDial()
    {
        while(Input.GetButton("Fire1"))     //While LMB is held down
        {
            MouseLook.freezeCam = true;     //Lock camera

            r.angularVelocity = Vector3.zero;
            float v = mouseMultiplier * Input.GetAxis("Mouse Y");   //Get speed to rotate dial by (mouseMultiplier set in inspector, why each dial moves at diff speed)
            transform.Rotate(0, v, 0);           //Rotate dial

            //mouseSpeed = Input.GetAxis("Mouse Y");
            //print(mouseSpeed);        //DEBUG

            //dialSource.PlayDelayed(mouseSpeed);   //For playing squeaking sound when knbos turn, still haven't fully figured out

            yield return null;
        }
        if(Input.GetButtonUp("Fire1"))      //When player releases LMB
        {
            MouseLook.freezeCam = false;    //Cam can move again
            StopCoroutine(SpinDial());      //Stops coroutine to rotate dial (I think it stops anyways on its own once you let go, but being safe)
        }
    }

    /*
    private void OnMouseUp()    //When player releases LMB
    {
        StopCoroutine(SpinDial());  //Stops coroutine to rotate dial (I think it stops anyways on its own once you let go, but being safe)
        MouseLook.freezeCam = false;    //Cam can move again

        //r.AddTorque(mouseSpeed * 5, 0, 0, ForceMode.VelocityChange);  //Extra - Rotate dials after lets go (not working yet)
    }
    */
}
