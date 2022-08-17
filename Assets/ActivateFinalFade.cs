using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFinalFade : MonoBehaviour
{
    public GameObject finalFade;

    // Start is called before the first frame update
    void Start()
    {
        finalFade.SetActive(true);
    }
}
