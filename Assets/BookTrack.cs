using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrack : MonoBehaviour
{
    public List<GameObject> listOfBooks = new List<GameObject>();
    public GameObject deactivateColl;
    public GameObject topCompartment;
    public GameObject topCompartmentOpen;
    public GameObject redKey;
    public GameObject poemP2;

    public void AddBook(GameObject book)
    {
        listOfBooks.Add(book);
        print(book.name + " has been added to list");       //DEBUG
    }

    public void RemoveBook(GameObject book)
    {
        listOfBooks.Remove(book);
        print(book.name + " has been removed from list");       //DEBUG
    }

    public void ResetBooks()
    {
        foreach (GameObject book in listOfBooks)
        {
            book.GetComponent<BookSelect>().ResetBook();
        }

        BookSelect.correctTotal = 0;
        listOfBooks.Clear();
    }

    public void DeactivatePerm()
    {
        deactivateColl.SetActive(true);
        redKey.SetActive(true);
        poemP2.SetActive(true);
        topCompartmentOpen.SetActive(true);
        topCompartment.SetActive(false);
    }

    /*
    public void DeactivateTemp()
    {
        deactivateColl.SetActive(true);
        Invoke("DeactivateDeactivate", 5f);
    }

    public void DeactivateDeactivate()
    {
        deactivateColl.SetActive(false);
    }
    */

}
