using UnityEngine;
using TMPro;

public class TesteAeroporto : MonoBehaviour
{

    [SerializeField] private AeroportosRoot airports;
    [SerializeField] private TextAsset jsonFile;

    [SerializeField] private TMP_InputField stateInput;
    private string state;
    [SerializeField] private TextMeshProUGUI iataCode;

    private void Start()
    {
        airports = JsonUtility.FromJson<AeroportosRoot>(jsonFile.text);
    }

    public void GetCode()
    {
        state = stateInput.text;
        stateInput.text = "";
        for(int i = 0; i < airports.aeroportos.Length; i++)
        {
            if(airports.aeroportos[i].estado == state)
            {
                iataCode.text = airports.aeroportos[i].iata;
                break;
            }
        }
    }
}
