using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI TimeCounted;
    public Week_2_Player Player;
    public Button Menu, Retry;

    public event Action UIActive;

    private void OnEnable()
    {
        UIActive += VICTORY;
    }
    private void OnDisable()
    {
        UIActive -= VICTORY;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void VICTORY()
    {
        this.gameObject.SetActive(true);
        TimeCounted.text = Player.ThisTimer.ObtenerTiempoTranscurrido().ToString("F2") + ": VICTORY!! ";
    }
    public void RETRY()
    {
        Player.ThisTimer.ReiniciarTemporizador();
        Player.ThisTimer.IniciarTemporizador();
        this.gameObject.SetActive(false);
    }
}