using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class FillInTheBlanks2 : MonoBehaviour
{
    private TextMeshProUGUI currentButtonText;
    private FillInTheBlanks2Field currentField;

    [SerializeField] private Image[] fieldImages;

    [SerializeField] private FillInTheBlanks2Field[] fields;
    private bool isCorrect = true;
    [SerializeField] private UnityEvent correctAction;

    [SerializeField] Color rightColor;
    [SerializeField] Color wrongColor;
    [SerializeField] Color normalColor;

    [SerializeField] AudioClip rightSound;
    [SerializeField] AudioClip wrongSound;

    public void SetCurrentButtonText(TextMeshProUGUI _buttonText)
    {
        currentButtonText = _buttonText;
    }

    public void SetCurrentField(FillInTheBlanks2Field _field)
    {
        currentField = _field;
    }

    public void ChangeButtonText(string _newText)
    {
        currentButtonText.text = _newText;        
    }

    public void SetUsedCard(FillInTheBlanks2Card _card)
    {
        if (currentField.isFilled)
        {
            currentField.usedCard.SetActive(true);            
        }
        else
        {
            currentField.isFilled = true;
        }
        currentField.usedCardIndex = _card.index;
        currentField.usedCard = _card.gameObject;
    }

    public void CheckFields()
    {
        for(int i = 0; i < fields.Length; i++)
        {
            if(fields[i].usedCardIndex != i)
            {
                isCorrect = false;
                fieldImages[i].color = wrongColor;
            }
            else
            {
                fieldImages[i].color = rightColor;
            }
        }

        StartCoroutine(ChangeBoxColor());
    }

    private IEnumerator ChangeBoxColor()
    {
        if (isCorrect)
        {
            AudioPlayerController.instance.PlaySFX(rightSound);
        }
        else
        {
            AudioPlayerController.instance.PlaySFX(wrongSound);
        }

        yield return new WaitForSeconds(1.0f);

        for(int i = 0; i < fieldImages.Length; i++)
        {
            fieldImages[i].color = normalColor;
        }

        if (isCorrect)
        {
            correctAction.Invoke();
        }
        else
        {
            isCorrect = true;
        }
    }
}