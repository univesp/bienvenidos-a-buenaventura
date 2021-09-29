using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

//Esse script será usado para pegar os dados que o jogador vai escrever no passaporte
public class PlayerPersonalData : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private Image nameInputImage;

    [SerializeField] private TMP_InputField playerSurname;
    [SerializeField] private Image surenameInputImage;

    [SerializeField] private Color errorColor;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color toogleNormalColor;

    [SerializeField] private Toggle[] playerGender;
    [SerializeField] private Image[] toogleBackground;
    [SerializeField] private GameObject nextButton;

    [SerializeField] private UnityEvent actions;

    [SerializeField] private AudioClip errorSound;

    public void SetPlayerName()
    {
        PlayerPrefs.SetString("Nome", playerName.text);        
    }

    public void SetPlayerSurname()
    {
        PlayerPrefs.SetString("Sobrenome", playerSurname.text);
    }

    public void SetFemaleGender()
    {
        PlayerPrefs.SetInt("Genero", 0);
    }

    public void SetMaleGender()
    {
        PlayerPrefs.SetInt("Genero", 1);
    }

    public void CheckFilledFields()
    {        
        if(playerName.text != "" && playerSurname.text != "" && playerGender[0].isOn || playerName.text != "" && playerSurname.text != "" && playerGender[1].isOn)
        {
            actions.Invoke();
        }
        else
        {
            Debug.Log("Entrou");
            StartCoroutine(ChangeColor());
        }
    }

    private IEnumerator ChangeColor()
    {
        if(playerName.text == "")
        {
            nameInputImage.color = errorColor;
        }

        if(playerSurname.text == "")
        {
            surenameInputImage.color = errorColor;
        }

        if(!playerGender[0].isOn && !playerGender[1].isOn)
        {
            toogleBackground[0].color = errorColor;
            toogleBackground[1].color = errorColor;
        }

        AudioPlayerController.instance.PlaySFX(errorSound);

        yield return new WaitForSeconds(1.0f);

        nameInputImage.color = normalColor;
        surenameInputImage.color = normalColor;
        toogleBackground[0].color = toogleNormalColor;
        toogleBackground[1].color = toogleNormalColor;
    }
}
