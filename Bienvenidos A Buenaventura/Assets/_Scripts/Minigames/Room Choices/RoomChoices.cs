using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomChoices : MonoBehaviour
{
    [SerializeField] private int maxActiveToggles;    
    private bool canActivate = true;
    private int qtd;

    [SerializeField] private Toggle[] toggles;

    public void CheckToggles()
    {
        qtd = 0;
        for (int i = 0; i < toggles.Length; i++)
        {
            if(toggles[i].isOn)
            {
                qtd++;
            }
        }

        if (canActivate)
        {
            if (qtd == maxActiveToggles)
            {
                canActivate = false;
                for (int i = 0; i < toggles.Length; i++)
                {
                    if (!toggles[i].isOn)
                    {
                        toggles[i].interactable = false;
                    }
                }
            }
        }
        else
        {
            if(qtd < maxActiveToggles)
            {
                canActivate = true;
                for (int i = 0; i < toggles.Length; i++)
                {
                    if (!toggles[i].interactable)
                    {
                        toggles[i].interactable = true;
                    }
                }
            }
        }
    }
}
