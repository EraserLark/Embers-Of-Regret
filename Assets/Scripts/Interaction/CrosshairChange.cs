using UnityEngine;

public class CrosshairChange : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject crosshair;
    public CrosshairImgSwap crossImgSwap;
    RaycastHit hit;

    void Update()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            string hitTag = hit.transform.tag;

            switch (hitTag)
            {
                case "Item":
                    crossImgSwap.SwapImg(1);
                    break;

                case "Spot":
                    crossImgSwap.SwapImg(2);
                    break;

                case "Note":
                    crossImgSwap.SwapImg(3);
                    break;

                case "Candle":
                    crossImgSwap.SwapImg(4);
                    break;

                case "Lock":
                    crossImgSwap.SwapImg(5);
                    break;

                default:
                    crossImgSwap.SwapImg(0);
                    break;
            }
        }
        else
        {
            crossImgSwap.SwapImg(0);
        }
    }
}
