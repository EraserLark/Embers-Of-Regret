using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSelect : ObjectInteractable
{
    public bool correctBook = false;
    public static int selectTotal = 0;
    public static int correctTotal = 0;

    AudioSource bookSource;
    BookTrack bookTrack;

    public override void Awake()
    {
        //base.Awake();

        bookSource = gameObject.GetComponent<AudioSource>();
        bookTrack = GetComponentInParent<BookTrack>();
    }

    public override void Selected()
    {
        base.Selected();

        bookSource.Play();  //Play book slide sfx

        if(state)
        {
            gameObject.transform.Translate(Vector3.left * 2, Space.Self);
            if (correctBook)
            {
                correctTotal++;
            }

            bookTrack.AddBook(gameObject);
            selectTotal++;
            //print(bookTrack.listOfBooks.Count);       DEBUG
        }
        else if(!state)
        {
            gameObject.transform.Translate(Vector3.right* 2, Space.Self);
            if (correctBook)
            {
                correctTotal--;
            }

            bookTrack.RemoveBook(gameObject);
            selectTotal--;
        }

        if (correctTotal >= 4)
        {
            print("Correct!");
            bookTrack.DeactivatePerm();     //Prevents player from further interacting with books on shelf, opens top copartment
        }
        else if (selectTotal >= 4)
        {
            print("Nope!");
            //bookTrack.DeactivateTemp();
            bookTrack.ResetBooks();
        }
    }

    public void ResetBook()
    {
        gameObject.transform.Translate(Vector3.right * 2, Space.Self);
        bookSource.Play();
        state = false;
        correctTotal = 0;
        selectTotal = 0;
    }
}
