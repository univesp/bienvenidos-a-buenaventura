using UnityEngine;
using System;

//Esse script será chamado uma vez no jogo para guardar o dia em que ele está sendo jogado
public class CurrentTimeGetter : MonoBehaviour
{
    private DateTime day;

    private void Start()
    {
        day = DateTime.Today;
        PlayerPrefs.SetString("DiaAtual", day.ToString("dd"));
        PlayerPrefs.SetString("DiaFuturo", day.AddDays(5d).ToString("dd"));
    }
}