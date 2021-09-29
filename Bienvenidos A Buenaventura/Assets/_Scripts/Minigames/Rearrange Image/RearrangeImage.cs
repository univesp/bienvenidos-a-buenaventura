using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RearrangeImage : MonoBehaviour
{
    private Button button1, button2;
    private Vector3 tempPosition;
    [SerializeField] private RearrangeImageCard card1, card2;

    [SerializeField] private List<RearrangeImageCard> cards;
    [SerializeField] private int card1Index, card2Index;

    private int wrongIndex;

    [SerializeField] private UnityEvent correctActions;

    [SerializeField] private Color wrongColor;
    [SerializeField] private Color rightColor;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color selectedColor;

    [SerializeField] private AudioClip wrongSound;
    [SerializeField] private AudioClip rightSound;

    public void SetButtons(Button _button)
    {
        if(button1 == null)
        {            
            button1 = _button;            
        }
        else
        {            
            button2 = _button;
            ChangePlaces();
        }
    }

    public void SetCards(RearrangeImageCard _card)
    {
        if(card1 == null)
        {
            card1 = _card;
            card1.image.color = selectedColor;
        }
        else
        {
            card2 = _card;
        }
    }

    private void ChangePlaces()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            if(cards[i].index == card1.index)
            {                
                card1Index = i;
                break;
            }
        }
                
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].index == card2.index)
            {
                card2Index = i;
                break;
            }
        }
        
        cards[card1Index] = card2;
        cards[card2Index] = card1;
        
        tempPosition = button1.transform.localPosition;
        button1.transform.localPosition = button2.transform.localPosition;
        button2.transform.localPosition = tempPosition;

        card1.image.color = normalColor;

        button1 = null;
        button2 = null;
        card1 = null;
        card2 = null;
    }

    public void CheckCardsOrder()
    {
        if(CheckOrder())
        {
            StartCoroutine(PlayCorrectSound());
        }
        else
        {
            StartCoroutine(ChangeBoxWrongColors());
        }
    }

    private bool CheckOrder()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            if (cards[i].index != i)
            {
                wrongIndex = i;
                return false;
            }
            else
            {
                cards[i].image.color = rightColor;
            }
        }
        return true;
    }

    private IEnumerator ChangeBoxWrongColors()
    {
        for (int i = wrongIndex; i < cards.Count; i++)
        {
            cards[i].image.color = wrongColor;
        }

        AudioPlayerController.instance.PlaySFX(wrongSound);

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].image.color = normalColor;
        }
    }

    private IEnumerator PlayCorrectSound()
    {
        AudioPlayerController.instance.PlaySFX(rightSound);
        yield return new WaitForSeconds(1.0f);

        correctActions.Invoke();
    }
}
