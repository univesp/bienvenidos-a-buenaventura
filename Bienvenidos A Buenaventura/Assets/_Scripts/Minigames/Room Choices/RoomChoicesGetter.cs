using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RoomChoicesGetter : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private UnityEvent actions;

    public void GetRoomType()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
            if(toggles[i].isOn)
            {
                switch(i)
                {
                    case 0:
                        PlayerPrefs.SetString("Quarto", "interior");
                        break;
                    case 1:
                        PlayerPrefs.SetString("Quarto", "exterior");
                        break;
                }
            }
        }
        actions.Invoke();
    }

    public void GetObjects()
    {
        int objectQtd = 0;

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                switch (i)
                {
                    case 0:
                        PlayerPrefs.SetString(string.Format("Objeto{0}", (objectQtd + 1).ToString()), "ducha");
                        break;
                    case 1:
                        PlayerPrefs.SetString(string.Format("Objeto{0}", (objectQtd + 1).ToString()), "minibar");
                        break;
                    case 2:
                        PlayerPrefs.SetString(string.Format("Objeto{0}", (objectQtd + 1).ToString()), "televisón");
                        break;
                    case 3:
                        PlayerPrefs.SetString(string.Format("Objeto{0}", (objectQtd + 1).ToString()), "aire acondicionado");
                        break;
                    case 4:
                        PlayerPrefs.SetString(string.Format("Objeto{0}", (objectQtd + 1).ToString()), "bañera");
                        break;
                    case 5:
                        PlayerPrefs.SetString(string.Format("Objeto{0}", (objectQtd + 1).ToString()), "secador de pelo");
                        break;
                    case 6:
                        PlayerPrefs.SetString(string.Format("Objeto{0}", (objectQtd + 1).ToString()), "caja fuerte");
                        break;
                    case 7:
                        PlayerPrefs.SetString(string.Format("Objeto{0}", (objectQtd + 1).ToString()), "calefacción");
                        break;
                }
                objectQtd++;
            }
        }
        actions.Invoke();
    }
}