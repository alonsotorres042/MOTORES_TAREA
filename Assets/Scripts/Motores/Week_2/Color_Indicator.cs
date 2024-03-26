using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Indicator : MonoBehaviour
{
    Image ThisImage;
    public Week_2_Player Player;
    void Start()
    {
        ThisImage = GetComponent<Image>();
    }
    void Update()
    {
        ThisImage.fillAmount = Player.CurrentLife / 10;
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