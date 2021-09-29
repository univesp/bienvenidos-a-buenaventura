using UnityEngine;
using TMPro;

public class SpellingGetSurname : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI header;

    private void Start()
    {
        header.text = string.Format("Deletrea {0}:", PlayerPrefs.GetString("Sobrenome", "Santos"));
    }
}