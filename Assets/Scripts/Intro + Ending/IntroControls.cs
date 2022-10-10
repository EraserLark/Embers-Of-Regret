using UnityEngine;
using UnityEngine.UI;

public class IntroControls : MonoBehaviour
{
    public Button next;
    public Button back;
    public GameObject fadeOut;
    int pageCount = 0;

    void Start()
    {
        pageCount = 1;
        next.onClick.AddListener(Next);
    }

    void Next()
    {
        pageCount++;
        print(pageCount);
    }

    void Back()
    {
        pageCount--;
    }
}
