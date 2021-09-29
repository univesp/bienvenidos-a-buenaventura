using UnityEngine;
using UnityEngine.EventSystems;

//Esse script vai na imagem de fundo dos caracteres especiais (o fundo semitransparente)
public class VirtualKeyboardHideSpecialCharacter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject[] specialCharacters;
    public void OnPointerClick(PointerEventData eventData)
    {
        for(int i = 0; i < specialCharacters.Length; i++)
        {
            specialCharacters[i].SetActive(false);
        }
    }
}
