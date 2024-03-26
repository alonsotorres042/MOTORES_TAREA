using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor.UI;

public class Timer : MonoBehaviour
{
    public float IniTIme = 0f;
    private float runningTime = 0f;
    public bool isCounting = true;
    private TextMeshProUGUI MyTMP;

    void Start()
    {
        MyTMP = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (isCounting)
        {
            runningTime += Time.deltaTime;
            MyTMP.text = "Tiempo transcurrido: " + runningTime.ToString("F2") + " segundos";
        }
    }

    public void IniciarTemporizador()
    {
        runningTime = IniTIme;
        isCounting = true;
    }

    public void DetenerTemporizador()
    {
        isCounting = false;
    }

    public void ReiniciarTemporizador()
    {
        runningTime = IniTIme;
    }

    public float ObtenerTiempoTranscurrido()
    {
        return runningTime;
    }
}