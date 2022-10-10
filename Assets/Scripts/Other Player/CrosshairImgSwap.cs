using UnityEngine;
using UnityEngine.UI;

public class CrosshairImgSwap : MonoBehaviour
{
    public Sprite[] crosshairIconOptions = new Sprite[6];
    public Color[] crosshairColorOptions = new Color[6];

    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = crosshairIconOptions[0];
    }

    public void SwapImg(int caseNum)
    {
        gameObject.GetComponent<Image>().sprite = crosshairIconOptions[caseNum];
        gameObject.GetComponent<Image>().color = crosshairColorOptions[caseNum];
    }
}
