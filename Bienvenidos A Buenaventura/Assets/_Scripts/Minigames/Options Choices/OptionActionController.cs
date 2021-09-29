using UnityEngine;
using UnityEngine.Events;

//Esse script contém as ações que vão acontecer quando o jogador escolher uma das opções
public class OptionActionController : MonoBehaviour
{   
    public string optionText;
    [SerializeField] public UnityEvent optionAction;

    private void Start()
    {
        if (optionText.Contains("JUNTOS"))
        {
            if (PlayerPrefs.GetInt("Genero", 1) == 0)
            {
                optionText = optionText.Replace("JUNTOS", "juntos");
            }
            else
            {
                optionText = optionText.Replace("JUNTOS", "juntas");
            }
        }

        if (optionText.Contains("ALEMÃO"))
        {
            if (PlayerPrefs.GetInt("Genero", 1) == 0)
            {
                optionText = optionText.Replace("ALEMÃO", "alemán");
            }
            else
            {
                optionText = optionText.Replace("ALEMÃO", "alemana");
            }
        }

        if (optionText.Contains("BRASILEIRO"))
        {
            if (PlayerPrefs.GetInt("Genero", 1) == 0)
            {
                optionText = optionText.Replace("BRASILEIRO", "brasileño");
            }
            else
            {
                optionText = optionText.Replace("BRASILEIRO", "brasileña");
            }
        }

        if (optionText.Contains("DIAFUTURO"))
        {
            optionText = optionText.Replace("DIAFUTURO", PlayerPrefs.GetString("DiaFuturo", "05"));
        }

        if (optionText.Contains("DIA"))
        {
            optionText = optionText.Replace("DIA", PlayerPrefs.GetString("DiaAtual", "01"));
        }
    }

    public void CallOptionAction()
    {
        optionAction.Invoke();
    }
}
