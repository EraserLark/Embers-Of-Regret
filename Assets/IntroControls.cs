using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroControls : MonoBehaviour
{
    public Button next;
    public Button back;
    public GameObject fadeOut;
    int pageCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        pageCount = 1;
        next.onClick.AddListener(Next);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Next()
    {
        pageCount++;
        print(pageCount);
        //Transition page
    }

    void Back()
    {
        pageCount--;
        //Transition Page
    }
}
