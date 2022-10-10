using UnityEngine;

public class SafeHandle : ObjectInteractable
{
    public int numOfCorrectDials = 0;
    bool refreshCalled = false;

    public GameObject safeDoor;
    public GameObject dials;
    public AudioSource knobSource;

    public override void Selected()
    {
        knobSource.Play();

        if(numOfCorrectDials >= 4)
        {
            safeDoor.GetComponent<AudioSource>().Play();

            safeDoor.transform.eulerAngles = new Vector3(90, 90, 0);    //Flips door open
            dials.SetActive(false);
        }
        else
        {
            //Switches UI icon to 'Lock' briefly, to indicate the safe is not unlocked
            if (refreshCalled)
            {
                CancelInvoke("Refresh");
            }
            refreshCalled = true;
            gameObject.tag = "Lock";
            Invoke("Refresh", 3f);
        }
    }

    private void Refresh()
    {
        gameObject.tag = "Item";
        refreshCalled = false;
    }
}
