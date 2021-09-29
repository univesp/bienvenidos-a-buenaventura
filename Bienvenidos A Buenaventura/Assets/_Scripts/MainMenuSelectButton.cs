using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenuSelectButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;

    [Header("Selected color")]
    public Color selectedColor;
    [Header("Unselected text color")]
    public Color unselectedTextColor;
    [Header("Unselected image color")]
    public Color unselectedImageColor;

    public TextMeshProUGUI text;
    public Image[] image;

    //Muda as cores e avisa que o botão está selecionado
    public void OnSelect(BaseEventData eventData)
    {

        text.color = selectedColor;
        image[0].color = selectedColor;
        image[1].color = selectedColor;
    }

    //Muda as cores das imagens e avisa que o botão não está selecionado
    public void OnDeselect(BaseEventData eventData)
    {

        text.color = unselectedTextColor;
        image[0].color = unselectedImageColor;
        image[1].color = unselectedImageColor;
    }

    //Muda as cores das imagens e avisa que o botão está selecionado
    public void OnPointerEnter(PointerEventData eventData)
    {

        text.color = selectedColor;
        image[0].color = selectedColor;
        image[1].color = selectedColor;
    }

    //Muda as cores das imagens e avisa que o botão não está selecionado
    public void OnPointerExit(PointerEventData eventData)
    {

        text.color = unselectedTextColor;
        image[0].color = unselectedImageColor;
        image[1].color = unselectedImageColor;
    }

    //Ao desativar, ele tira a seleção do botão e reseta as cores
    private void OnDisable()
    {
        button.OnDeselect(null);

        text.color = unselectedTextColor;
        image[0].color = unselectedImageColor;
        image[1].color = unselectedImageColor;
    }
}
