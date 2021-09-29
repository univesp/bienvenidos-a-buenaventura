using UnityEngine;
using TMPro;
using System;

public class TesteDate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textmesh;
    private DateTime day;

    private void Start()
    {
        day = DateTime.Today;        
        textmesh.text = "Data: " + day.ToString("dd") + ", " + day.AddDays(6d).ToString("dd");

    }
}