using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public float jumpscareLength;

    public MouseInteract mouseInteract;
    public MonsterFollow2 monsterFollow;
    public GameObject jumpscareZone;
    public Vector3 jumpscareSpot;

    public GameObject playerDeath;
    public GameObject monster;
    public Animation nom;

    public GameObject noteOverlay;

    BookTrack bookTrack;

    //public Animator anim;
    public AnimationControl animationControl;

    private void Awake()
    {
        jumpscareSpot = jumpscareZone.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Collided with " + other.tag);     //DEBUG

        if (other.tag == "Monster")
        {
            //NEED TO STOP MouseInteract ALTOGETHER, how to do that?

            jumpscareSpot = jumpscareZone.transform.position;
            jumpscareZone.GetComponent<AudioSource>().Play();

            MouseLook.freezeCam = true;
            mouseInteract.StopCoroutine();

            animationControl.monsterColl = true;

            noteOverlay.SetActive(false);

            gameObject.transform.rotation = jumpscareZone.transform.rotation;
            gameObject.transform.position = jumpscareSpot;

            monsterFollow.FreezeMon();
            nom.Play();

            //Run player death function
            FindObjectOfType<PlayerDeath>().GameOverCountdown(jumpscareLength);
            
            //Will run script to kill player (Not very efficient, better way to run this?)
                                                            //Script can be found attached to 'GameManager'
            
        }
        else if(other.tag == "Exit")
        {
            //Cursor.lockState = CursorLockMode.Confined;
            //print(Cursor.lockState + "Exit");      //DEBUG
            bookTrack.ResetBooks();     //Reset bookshelf puzzle
            MonsterFollow2.candleLit = false;
            SceneManager.LoadScene(9);  //Load Victory screen
        }
    }
}
