using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esse script vai junto com o RearrangeSenteces.cs. Ele guarda os objetos que recebem os botões das sentenças e verifica se os botões estão dentro da área
public class RearrangeSentencesContainer : MonoBehaviour
{
    [SerializeField] private RearrangeSentences rearrangeSentences;

    public Transform[] sentenceContainer;
    [HideInInspector] public int activeIndex = 0;

    public RectTransform layoutArea;

    public List<RearrangeSentencesCard>[] containerCardList;

    private RearrangeSentencesCard lastChild;
    private RearrangeSentencesCard firstChild;

    private void Start()
    {
        containerCardList = new List<RearrangeSentencesCard>[sentenceContainer.Length];
        for (int i = 0; i < containerCardList.Length; i++)
        {
            containerCardList[i] = new List<RearrangeSentencesCard>();
        }
    }

    //Muda em qual linha os botões serão colocados quando eles forem pra lista da sentença
    public void SetActiveContainter(int _index)
    {
        activeIndex += _index;
        if (activeIndex < 0)
        {
            activeIndex = 0;
        }
    }

    //Esse método é chamado pelo RearrangeSentencesCard. Ele verifica a posição dos filhos e reposiciona se possível
    public void CheckChildrenPosition()
    {
        if (sentenceContainer.Length > 1 && containerCardList[1].Count != 0)
        {
            StartCoroutine(WaitToCheckChildren());
        }
    }

    private IEnumerator WaitToCheckChildren()
    {      
        //Passa de linha em linha, e reposiciona todos os filhos que puder até não caber mais, então vai para a próxima linha
        for (int i = 0; i < sentenceContainer.Length - 1; i++)
        {
            while(true)
            {
                yield return new WaitForEndOfFrame();
                
                if (containerCardList[i + 1].Count > 0)
                {
                    firstChild = containerCardList[i + 1][0];
                    lastChild = containerCardList[i][containerCardList[i].Count - 1];
                    if (firstChild.rect.anchoredPosition.x + firstChild.rect.rect.width / 2 + lastChild.rect.anchoredPosition.x + lastChild.rect.rect.width / 2 <= layoutArea.rect.width)
                    {
                        containerCardList[i + 1].Remove(containerCardList[i + 1][0]);
                        firstChild.gameObject.transform.SetParent(lastChild.transform.parent);
                        containerCardList[i].Add(firstChild);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }                
            }
        }     
        
        //Verifica qual a linha atual jogável
        for(int i = 0; i < sentenceContainer.Length; i++)
        {
            Debug.Log(containerCardList[i].Count);
            if(containerCardList[i].Count == 0)
            {
                activeIndex = i - 1;
                break;
            }

        }
    }
}
