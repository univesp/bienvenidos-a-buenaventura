using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Esse script vai em todos os botões com as palavras
public class RearrangeSentencesCard : MonoBehaviour
{
    [SerializeField] private RearrangeSentences rearrangeSentences;
    [SerializeField] private RearrangeSentencesContainer container;

    [Header("Card Variables")]
    public RectTransform rect;
    public int cardIndex;
    public Image image;

    public bool isInPhrase;

    public void MoveCard()
    {
        if(isInPhrase)
        {
            MoveToPile();
        }
        else
        {
            MoveToSentence();
        }
    }

    private void MoveToSentence()
    {
        isInPhrase = true;

        gameObject.transform.SetParent(container.sentenceContainer[container.activeIndex]);

        rearrangeSentences.cardList.Add(this);
        rearrangeSentences.OnCardAdded();

        container.containerCardList[container.activeIndex].Add(this);

        StartCoroutine(CheckCardPosition());
    }

    private void MoveToPile()
    {
        isInPhrase = false;        

        gameObject.transform.SetParent(rearrangeSentences.cardPile);
        for(int i = 0; i < rearrangeSentences.cardList.Count; i++)
        {
            if(rearrangeSentences.cardList[i].cardIndex == cardIndex)
            {
                rearrangeSentences.cardList.Remove(rearrangeSentences.cardList[i]);
                break;
            }
        }

        for (int i = 0; i < container.sentenceContainer.Length; i++)
        {
            for (int j = 0; j < container.containerCardList[i].Count; j++)
            {
                if (container.containerCardList[i][j].cardIndex == cardIndex)
                {
                    container.containerCardList[i].Remove(container.containerCardList[i][j]);
                    break;
                }
                else
                {
                    continue;
                }
            }            
        }

        rearrangeSentences.OnCardAdded();

        if (container.sentenceContainer[container.activeIndex].childCount == 0)
        {
            container.SetActiveContainter(-1);
        }

        container.CheckChildrenPosition();
    }

    private IEnumerator CheckCardPosition()
    {
        yield return new WaitForEndOfFrame();
        if (rect.anchoredPosition.x + rect.rect.width / 2 > container.layoutArea.rect.width)
        {
            container.containerCardList[container.activeIndex].Remove(container.containerCardList[container.activeIndex][container.containerCardList[container.activeIndex].Count - 1]);
            container.SetActiveContainter(1);            
            gameObject.transform.SetParent(container.sentenceContainer[container.activeIndex]);
            container.containerCardList[container.activeIndex].Add(this);
        }
    }
}