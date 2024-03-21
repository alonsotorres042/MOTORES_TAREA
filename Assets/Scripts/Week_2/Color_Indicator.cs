using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Indicator : MonoBehaviour
{
    Image ThisImage;
    void Start()
    {
        ThisImage = GetComponent<Image>();
    }
    public void ChageToRed()
    {
        ThisImage.color = Color.red;
    }
    public void ChageToGreen()
    {
        ThisImage.color = Color.green;
    }
    public void ChageToBlue()
    {
        ThisImage.color = Color.blue;
    }
}
