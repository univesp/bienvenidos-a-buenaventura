using UnityEngine;
using TMPro;

public class TravelCardDataGetter : MonoBehaviour
{
    public void SetName(TextMeshProUGUI _name)
    {
        _name.text = string.Format("{0} {1}",PlayerPrefs.GetString("Nome", "Fulano").ToUpper(), PlayerPrefs.GetString("Sobrenome", "Silva").ToUpper());
    }

    public void SetCode(TextMeshProUGUI _code)
    {
        _code.text = PlayerPrefs.GetString("Codigo", "GRU");
    }

    public void SetDay(TextMeshProUGUI _day)
    {
        _day.text = PlayerPrefs.GetString("DiaAtual", "11");
    }
}
