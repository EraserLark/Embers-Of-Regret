using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public MouseInteract mouseInteract;

    public GameObject jumpscareZone;
    public Vector3 jumpscareSpot;
    public float jumpscareLength;
    public GameObject playerDeath;

    public MonsterFollow2 monsterFollow;
    public GameObject monster;
    public Animation nom;

    public GameObject noteOverlay;
    BookTrack bookTrack;

    public AnimationControl animationControl;

    private void Awake()
    {
        jumpscareSpot = jumpscareZone.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Player collides with Monster
        if (other.tag == "Monster")
        {
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
        }
        //Player collides with the Exit
        else if(other.tag == "Exit")
        {
            bookTrack.ResetBooks();
            MonsterFollow2.candleLit = false;
            SceneManager.LoadScene(9);  //Load Victory screen
        }
    }
}
