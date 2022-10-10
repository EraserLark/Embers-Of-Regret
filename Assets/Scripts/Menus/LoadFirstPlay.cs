using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstPlay : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(1);  //Load FirstPlaythrough
    }
}
