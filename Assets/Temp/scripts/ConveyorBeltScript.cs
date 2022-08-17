using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltScript : MonoBehaviour
{

    public GameObject moveZone;
    public Transform endPoint;
    public float speed;

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards (other.transform.position, endPoint.position, speed * Time.deltaTime);    
    }

}
