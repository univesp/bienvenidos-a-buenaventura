using UnityEngine;
using TMPro;

public class CountryStateAndCodeSetter : MonoBehaviour
{
    [SerializeField] private TMP_InputField stateInput;
    [SerializeField] private TextAsset json;
    [SerializeField] private AeroportosRoot airports;
    [SerializeField] private GameObject nextButton;

    private void Start()
    {
        airports = JsonUtility.FromJson<AeroportosRoot>(json.text);
    }

    public void SetStateAndCode()
    {
        PlayerPrefs.SetString("Estado", stateInput.text);

        for (int i = 0; i < airports.aeroportos.Length; i++)
        {
            if (airports.aeroportos[i].estado == stateInput.text)
            {
                PlayerPrefs.SetString("Codigo", airports.aeroportos[i].iata);
                break;
            }
        }
    }

    public void CheckIfHasText()
    {
        if(stateInput.text != "" || stateInput.text != " " || stateInput.text != null)
        {
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }
    }
}