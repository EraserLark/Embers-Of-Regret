using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationControl : MonoBehaviour
{
    public Animator anim;

    public NavMeshAgent agent;

    public bool monsterColl = false;

    public bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (agent.velocity != Vector3.zero)
        {
            //Animated moving
            anim.SetBool("walk", true);
        }*/
        if (walking)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        if (monsterColl)
        {
            anim.SetBool("walk", false);
            anim.SetBool("death", true);
        }
    }
}
