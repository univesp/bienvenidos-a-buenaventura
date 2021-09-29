using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

//Esse script contém a lógica que verifica se a ordem está correta ou não
public class RearrangeSentences : MonoBehaviour
{
    [HideInInspector]
    public List<RearrangeSentencesCard> cardList = new List<RearrangeSentencesCard>();

    [Header("Sentence Variable")]
    [SerializeField] private int wordCount;

    public Transform cardPile;

    [SerializeField] private UnityEvent correctActions;

    [SerializeField] GameObject endButton;

    [SerializeField] private Color rightColor;
    [SerializeField] private Color wrongColor;
    [SerializeField] private Color normalColor;
    private int wrongIndex;

    [SerializeField] AudioClip rightSound;
    [SerializeField] AudioClip wrongSound;

    public void OnCardAdded()
    {
        if(cardList.Count == wordCount)
        {
            endButton.SetActive(true);
        }
        else
        {
            endButton.SetActive(false);
        }
    }

    public void CheckSentences()
    {
        if (CheckSentenceOrder())
        {
            StartCoroutine(PlayCorrectSound());
        }
        else
        {
            StartCoroutine(ChangeBoxWrongColors());
        }
    }

    private bool CheckSentenceOrder()
    {
        for(int i = 0; i < cardList.Count; i++)
        {
            if(cardList[i].cardIndex != i)
            {
                wrongIndex = i;
                return false;
            }            
            else
            {
                cardList[i].image.color = rightColor;
            }
        }
        return true;
    }

    private IEnumerator ChangeBoxWrongColors()
    {
        for(int i = wrongIndex; i < cardList.Count; i++)
        {
            cardList[i].image.color = wrongColor;
        }

        AudioPlayerController.instance.PlaySFX(wrongSound);

        yield return new WaitForSeconds(1.0f);        

        for(int i = 0; i < cardList.Count; i++)
        {
            cardList[i].image.color = normalColor;
        }
    }

    private IEnumerator PlayCorrectSound()
    {
        AudioPlayerController.instance.PlaySFX(rightSound);
        yield return new WaitForSeconds(1.0f);        

        correctActions.Invoke();
    }
}
