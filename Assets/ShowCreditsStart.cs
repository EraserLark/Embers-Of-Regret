﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCreditsStart : MonoBehaviour
{
    public GameObject credits;
    public void ShowCredits()
    {
        credits.SetActive(true);
    }
}
