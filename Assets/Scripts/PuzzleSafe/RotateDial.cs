using System.Collections;
using UnityEngine;

public class RotateDial : ObjectInteractable
{
    public float mouseMultiplier = 5f;
    Rigidbody r;

    public override void Awake()
    {
        r = gameObject.GetComponent<Rigidbody>();
    }

    public override void Selected()
    {
        StartCoroutine(SpinDial());
    }

    IEnumerator SpinDial()
    {
        while(Input.GetButton("Fire1"))
        {
            MouseLook.freezeCam = true;

            r.angularVelocity = Vector3.zero;
            float v = mouseMultiplier * Input.GetAxis("Mouse Y");   //mouseMultiplier is set diff for each dial, why they move at diff speeds
            transform.Rotate(0, v, 0);

            yield return null;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            MouseLook.freezeCam = false;
            StopCoroutine(SpinDial());
        }
    }
}
