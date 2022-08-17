using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    // private variable
    Animator animator;

    // This will run as soon as the script is initiated (similar to void Start)
    private void Awake()
    {
        // Testing
        Debug.Log("Animation script online");

        // Gives our variable a value / fills the 'container'
        animator = GetComponent<Animator>();

        // This enacts the 'BeginPlay' condition - causing IntroClip to play)
        animator.SetTrigger("BeginPlay");
    }

}
