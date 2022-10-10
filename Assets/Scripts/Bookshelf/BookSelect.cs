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
        bookSource = gameObject.GetComponent<AudioSource>();
        bookTrack = GetComponentInParent<BookTrack>();
    }

    public override void Selected()
    {
        base.Selected();
        bookSource.Play();

        if(state)
        {
            gameObject.transform.Translate(Vector3.left * 2, Space.Self);   //Book slides out
            if (correctBook)
            {
                correctTotal++;
            }

            bookTrack.AddBook(gameObject);
            selectTotal++;
        }
        else if(!state)
        {
            gameObject.transform.Translate(Vector3.right* 2, Space.Self);   //Book slides back in
            if (correctBook)
            {
                correctTotal--;
            }

            bookTrack.RemoveBook(gameObject);
            selectTotal--;
        }

        if (correctTotal >= 4)
        {
            bookTrack.DeactivatePerm();     //Prevents further interaction with bookshelf, opens top copartment
        }
        else if (selectTotal >= 4)
        {
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
